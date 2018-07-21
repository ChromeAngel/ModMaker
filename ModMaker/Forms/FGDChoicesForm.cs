using System.Data;
using LibModMaker;

namespace ModMaker
{
    /// <summary>
    /// UI for specifying the choices a mapper has for an enity property
    /// </summary>
    public partial class FGDChoicesForm
    {
        private ForgeGameData.ChoicesProperty _BaseProperty;

        private DataTable _Source;

        public FGDChoicesForm()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            _Source = new DataTable("Options");
            _Source.Columns.Add("Value");
            _Source.Columns.Add("Text");
        }

        public ForgeGameData.ChoicesProperty ChoicesProperty
        {
            get
            {
                _BaseProperty.choices.Clear();

                foreach (DataRow Row in _Source.Rows)
                {
                    _BaseProperty.choices.Add(Row["Value"].ToString(), Row["Text"].ToString());
                }

                return _BaseProperty;
            }
            set
            {
                _BaseProperty = value;

                if (value == null)
                    return;

                _Source.Rows.Clear();

                foreach (string ItemValue in _BaseProperty.choices.Keys)
                {
                    DataRow Row = _Source.NewRow();
                    Row["Value"] = ItemValue;
                    Row["Text"] = _BaseProperty.choices[ItemValue];
                    _Source.Rows.Add(Row);
                }

                dbgGrid.DataSource = _Source;
            }
        }


    }

}