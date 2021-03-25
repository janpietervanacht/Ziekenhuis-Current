using FormsAppZiekenhuis.DependencyInfra;
using System.Windows.Forms;
using Ziekenhuis.Business.Interfaces;

namespace FormsAppZiekenhuis
{
    public partial class FrmMainMenu : Form
    {
        readonly IClientManager _clientManager;
        readonly ICountryManager _countryManager;
        readonly IInvoiceManager _invoiceManager;
        readonly IConsultManager _consultManager;

        public FrmMainMenu()
        {
            InitializeComponent();
            // Dependency injection doe je één keer, namelijk in dit startscherm
            // We moeten werken met de out variabelen, dat zijn allemaal nieuwe managers 

            // DI: in de constructor van een object zitten alle objecten die dit object
            // gebruikt. Al deze objecten zijn geadministreerd als DI.
            Dependency.InitialiseerDI(out _clientManager, out _countryManager,
                                       out _invoiceManager, out _consultManager);  // Vraag Peter TODO hoe deze 2 te resolven

            //++++++++++++++++++++++++++++++++++++++++++
            // Als je meteen naar je form die je nu programmeert wil springen:
            //var XXX = new XXX(_clientManager);
            //XXX.ShowDialog();
        }

        private void MenuItemClientListView_Click(object sender, System.EventArgs e)
        {
            var frmClientListView = new FrmClientListView(_clientManager, _countryManager, _invoiceManager, _consultManager);
            frmClientListView.ShowDialog(); // modal form (lock parent form)
        }

        private void MenuItemCountryListBox_Click(object sender, System.EventArgs e)
        {
            var frmCountryListBox = new FrmCountryListBox(_clientManager, _countryManager);
            frmCountryListBox.ShowDialog(); // modal form (lock parent form)
        }

        private void MenuItemDragListBoxToListBox_Click(object sender, System.EventArgs e)
        {
            var frmDragDropListBoxToListBoxClients = new FrmDragDropListBoxToListBoxClients(_clientManager, _countryManager);
            frmDragDropListBoxToListBoxClients.ShowDialog(); // modal form (lock parent form)
        }
    }
}
