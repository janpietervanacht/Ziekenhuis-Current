using FormsAppZiekenhuis.DependencyInfra;
using System.Windows.Forms;
using Ziekenhuis.Business.Interfaces;

namespace FormsAppZiekenhuis
{
    public partial class FrmCountryListBox : Form
    {
        readonly IClientManager _clientManager;
        readonly ICountryManager _countryManager;

        public FrmCountryListBox(IClientManager clientManager,
                                 ICountryManager countryManager)
        {
            InitializeComponent();
            _clientManager = clientManager;  
            _countryManager = countryManager;  
        }

       
    }
}
