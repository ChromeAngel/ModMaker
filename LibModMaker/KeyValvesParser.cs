using System.IO;

namespace LibModMaker
{

    /// <summary>
    /// Helper class for parsing KeyValues files (see KeyValues.cs)
    /// </summary>
    internal class KeyValvesParser
    {
        protected KeyValuesInnerParser InnerParser = new KeyValuesInnerParser();

        protected KeyValues Context = null;

        public virtual KeyValues Parse(TextReader Source)
        {
            InnerParser = new KeyValuesInnerParser();
            InnerParser.ReadKey += InnerParser_ReadKey;
            InnerParser.SetCondition += InnerParser_SetCondition;
            InnerParser.SetEnd += InnerParser_SetEnd;
            InnerParser.SetLastKeyCondition += InnerParser_SetLastKeyCondition;
            InnerParser.SetStart += InnerParser_SetStart;

            InnerParser.Parse(Source);

            if (Context == null)
                return null;

            KeyValues Result = Context;

            Context = null;

            while (Result.Parent != null)
            {
                Result = Result.Parent;
            }

            return Result;
        }

        private void InnerParser_ReadKey(object sender, KeyValuesInnerParser.KeyEventArgs e)
        {
            KeyValues Key = new KeyValues(e.Key, KeyValues.UnQuote(e.Value), Context);
        }

        private void InnerParser_SetCondition(object Sender, KeyValuesInnerParser.SetStartEventArgs e)
        {
            Context.Condition = e.Key;
        }
        private void InnerParser_SetLastKeyCondition(object Sender, KeyValuesInnerParser.SetStartEventArgs e)
        {
            if (Context.Keys.Count == 0)
            {
                Context.Condition = e.Key;
            }
            else
            {
                Context.Keys[Context.Keys.Count - 1].Condition = e.Key;
            }
        }

        private void InnerParser_SetEnd(object sender, System.EventArgs e)
        {
            if (Context == null || Context.Parent == null)
                return;

            Context = Context.Parent;
        }

        private void InnerParser_SetStart(object sender, KeyValuesInnerParser.SetStartEventArgs e)
        {
            KeyValues Key = new KeyValues(e.Key, Context);

            Context = Key;
        }
    } //end class

}