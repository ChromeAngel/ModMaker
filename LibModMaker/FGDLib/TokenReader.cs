using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibModMaker.FGDLib
{
    public enum trtoken_t
    {
        TOKENSTRINGTOOLONG = -4,
        TOKENERROR = -3,
        TOKENNONE = -2,
        TOKENEOF = -1,
        OPERATOR,
        INTEGER,
        STRING,
        IDENT
    };

    class TokenReader
    {
        public static bool IsToken(string s1, string s2)
        {
            return s1 == s2;
        }

        private const int MAX_TOKEN = 128 + 1;
        private const int MAX_IDENT = 64 + 1;
        private const int MAX_STRING = 128 + 1;

        private int m_nLine;
        private int m_nErrorCount;

        private string m_szFilename;
        private string m_szStuffed;
        private bool m_bStuffed;
        private trtoken_t m_eStuffed;
        private FileStream m_fsStream;
        

        public TokenReader()
        {
            m_szFilename = null;
            m_nLine = 1;
            m_nErrorCount = 0;
            m_bStuffed = false;
        };

        public bool Open(string pszFilename)
        {
            m_fsStream = new FileStream(pszFilename, FileMode.Open, FileAccess.Read, FileShare.Read);
            m_szFilename = pszFilename;

            m_nLine = 1;
            m_nErrorCount = 0;
            m_bStuffed = false;

            return (m_fsStream.CanRead);
        }

        public struct Token
        {
            public trtoken_t tokentype;
            public string text;
        }

        public Token NextToken()
        {
            Token result  = new Token();
            result.text = "";

            if (!m_fsStream.CanRead)
            {
                result.tokentype = trtoken_t.TOKENEOF;

                return result;
            }

            //
            // If they stuffed a token, return that token.
            //
            if (m_bStuffed)
            {
                m_bStuffed = false;
                result.text = m_szStuffed;
                result.tokentype = m_eStuffed;

                return result;
            }

            SkipWhiteSpace();

            if (m_fsStream.Position == m_fsStream.Length)
            {
                result.tokentype = trtoken_t.TOKENEOF;

                return result;
            }

            if (fail())
            {
                result.tokentype = trtoken_t.TOKENEOF;

                return result;
            }

            char ch = get();

            //
            // Look for all the valid operators.
            //
            switch (ch)
            {
                case '@':
                case ',':
                case '!':
                case '+':
                case '&':
                case '*':
                case '$':
                case '.':
                case '=':
                case ':':
                case '[':
                case ']':
                case '(':
                case ')':
                case '{':
                case '}':
                case '\\':
                    {
                        result.text = ch.ToString();
                        result.tokentype = trtoken_t.OPERATOR;

                        return result;
                    }
            }

            //
            // Look for the start of a quoted string.
            //
            if (ch == '\"')
            {
                return GetString();
            }

            //
            // Integers consist of numbers with an optional leading minus sign.
            //
            if ( char.IsDigit(ch) || (ch == '-'))
            {
                do
                {
                    result.text = result.text + ch;

                    ch = get();
                    if (ch == '-')
                    {
                        result.tokentype = trtoken_t.TOKENERROR;
                        return result;
                    }
                } while (char.IsDigit(ch));

                //
                // No identifier characters are allowed contiguous with numbers.
                //
                if (char.IsLetter(ch) || (ch == '_'))
                {
                    result.tokentype = trtoken_t.TOKENERROR;
                    return result;
                }

                //
                // Put back the non-numeric character for the next call.
                //
                putback(ch);

                result.tokentype = trtoken_t.INTEGER;
                return result;
            }

            //
            // Identifiers consist of a consecutive string of alphanumeric
            // characters and underscores.
            //
            while (char.IsLetter(ch) || char.IsDigit(ch) || (ch == '_'))
            {
                result.text = result.text + ch;

                ch = get();
            }

            //
            // Put back the non-identifier character for the next call.
            //
            putback(ch);
            result.tokentype = trtoken_t.IDENT;
            return result;
        }

        public trtoken_t NextTokenDynamic(string ppszStore);
        public void Close();

        public void IgnoreTill(trtoken_t ttype, string pszToken);
        public void Stuff(trtoken_t ttype, string pszToken);
        public bool Expecting(trtoken_t ttype, string pszToken);
        public string Error(string error, params object[]);
        public trtoken_t PeekTokenType(string first = null, int maxlen = 0);

        public int GetErrorCount(void);


        // compiler can't generate an assignment operator since descended from std::ifstream
        private TokenReader(TokenReader const &);
        private int operator=(TokenReader const &);

        private Token GetString()
        {
            Token result = new Token();


            byte[] szBuf = new byte[1024];

            //
            // Until we reach the end of this string or run out of room in
            // the destination buffer...
            //
            while (true)
            {
                //
                // Fetch the next batch of text from the file.
                //
                m_fsStream.Read(szBuf, 0, 1024);
                get(szBuf, sizeof(szBuf), '\"');
                if (!m_fsStream.CanRead)
                {
                    result.tokentype = trtoken_t.TOKENEOF;
                    return result;
                }

                if (fail())
                {
                    // Just means nothing was read (empty string probably "")
                    clear();
                }

                //
                // Transfer the text to the destination buffer.
                //
                char* pszSrc = szBuf;
                while ((*pszSrc != '\0') && (nSize > 1))
                {
                    if (*pszSrc == 0x0d)
                    {
                        //
                        // Newline encountered before closing quote -- unterminated string.
                        //
                        *pszStore = '\0';
                        return TOKENSTRINGTOOLONG;
                    }
                    else if (*pszSrc != '\\')
                    {
                        *pszStore = *pszSrc;
                        pszSrc++;
                    }
                    else
                    {
                        //
                        // Backslash sequence - replace with the appropriate character.
                        //
                        pszSrc++;

                        if (*pszSrc == 'n')
                        {
                            *pszStore = '\n';
                        }

                        pszSrc++;
                    }

                    pszStore++;
                    nSize--;
                }

                if (*pszSrc != '\0')
                {
                    //
                    // Ran out of room in the destination buffer. Skip to the close-quote,
                    // terminate the string, and exit.
                    //
                    ignore(1024, '\"');
                    *pszStore = '\0';
                    return TOKENSTRINGTOOLONG;
                }

                //
                // Check for closing quote.
                //
                if (peek() == '\"')
                {
                    //
                    // Eat the close quote and any whitespace.
                    //
                    get();

                    bool bCombineStrings = SkipWhiteSpace();

                    //
                    // Combine consecutive quoted strings if the combine strings character was
                    // encountered between the two strings.
                    //
                    if (bCombineStrings && (peek() == '\"'))
                    {
                        //
                        // Eat the open quote and keep parsing this string.
                        //
                        get();
                    }
                    else
                    {
                        //
                        // Done with this string, terminate the string and exit.
                        //
                        *pszStore = '\0';
                        return STRING;
                    }
                }
            }
        }

        //-----------------------------------------------------------------------------
        // Purpose: Gets the next non-whitespace character from the file.
        // Input  : ch - Receives the character.
        // Output : Returns true if the whitespace contained the combine strings
        //			character '\', which is used to merge consecutive quoted strings.
        //-----------------------------------------------------------------------------
        private bool SkipWhiteSpace(void)
        {
	        bool bCombineStrings = false;

	        while (true)
	        {
		        char ch = get();

		        if ((ch == ' ') || (ch == '\t') || (ch == '\r') || (ch == 0))
		        {
			        continue;
		        }

		        if (ch == '+')
		        {
			        bCombineStrings = true;
			        continue;
		        }

		        if (ch == '\n')
		        {
			        m_nLine++;
			        continue;
		        }

		        if (!m_fsStream.CanRead)
		        {
			        return(bCombineStrings);
		        }

		        //
		        // Check for the start of a comment.
		        //
		        if (ch == '/')
		        {
			        if (peek() == '/')
			        {

                        ignore(1024, '\n');
                        m_nLine++;
			        }
		        }
		        else
		        {
                    //
                    // It is a worthy character. Put it back.
                    //
                    putback(ch);
			        return(bCombineStrings);
		        }
	        }
        } //end SkipWhiteSpace


    } //end class
}
