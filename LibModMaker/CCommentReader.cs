using System.IO;

namespace LibModMaker
{

/// <summary>
/// Read lines from a texct file stripping out the empty lines and C style comments
/// </summary>
/// <remarks></remarks>
public class CCommentReader : StreamReader
{

	public CCommentReader(string FilePath) : base(FilePath)
	{
	}

	public override string ReadLine()
	{
		string Result = base.ReadLine();

		if (Result == null)
			return null;

		Result = Result.Trim();

	    if (Result.Length == 0)
	    {
                return ReadLine();
            }

	    if (!Result.Contains("//"))
	    {
            return Result;
        }

		Result = Result.Substring(0, Result.IndexOf("//"));
		Result = Result.Trim();

	    if (Result.Length == 0)
	    {
            return ReadLine();
        }

		return Result;
	}
} //end class

}