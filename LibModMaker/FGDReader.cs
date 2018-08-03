namespace LibModMaker
{

    /// <summary>
    /// Read lines from and FGD file stripping out comments
    /// </summary>
public class FGDReader : CCommentReader
{

	private const char Quote = '"';

	private const char Plus = '+';

	private System.Text.StringBuilder Buffer = new System.Text.StringBuilder();
	internal FGDReader(string FilePath) : base(FilePath)
	{
	}

	public override string ReadLine()
	{
		string Result = ReadBuffer();

		if (Result == null) return null;

		Result = Result.Trim();

		if (Result.Length == 0) return ReadLine();

		if (!Result.EndsWith(Plus.ToString())) return Result;

		string Peek = ReadBuffer();

		Peek = Peek.Trim();

		if (Peek.StartsWith(Quote.ToString()))
        {
			Result = Result.TrimEnd(Plus).TrimEnd().TrimEnd(Quote) + Peek.Substring(1);
		} else {
			Result = Result.TrimEnd(Plus).TrimEnd();
		}

		if (Result.Length == 0)
        {
			Result = Peek;
		} else {
			Buffer.Append(Peek);
		}

		return Result;
	}

	protected string ReadBuffer()
	{
	    if (Buffer.Length == 0)
	    {
            return base.ReadLine();
        }

        string result = Buffer.ToString();

		Buffer.Length = 0;

	    return result;
	}
} //end class

}