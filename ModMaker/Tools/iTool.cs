using System.Drawing;
using LibModMaker;

namespace ModMaker
{
    /// <summary>
    /// Interface for tools to be exposed through the Mod Maker tools view
    /// </summary>
    public interface iTool
    {
        string Name { get; }
        Image Image { get; }
        string TipText { get; }
        bool IsValidForMod(SourceMod Game);
        void Launch(SourceMod Game);
    }

    /// <summary>
    /// Endtend iTool interface for tools that support being passed a file to work with (via drag and drop)
    /// </summary>
    public interface iFileTool : iTool
    {

        void LaunchFile(SourceMod Game, string FilePath);
    }

}