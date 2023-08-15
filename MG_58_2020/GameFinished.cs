using MG_58_2020.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MG_58_2020
{
    public partial class GameFinished : Form
    {
        public MemoryGameForm form;

        private IServiceFactory serviceFactory;

        public GameFinished()
        {
            InitializeComponent();
            serviceFactory = new ServiceFactory();
        }

        public void FillDataGridView()
        {
            IResultsService resultsService = serviceFactory.GetResultService();
            List<ScoreResult> results = resultsService.GetResults(form.podela, null);
            scoreGridView.Rows.Clear();
            foreach(var result in results)
            { 
                scoreGridView.Rows.Add(result.Id, result.Ime, result.Vreme, result.BrojPoteza);
            }
        }

        private void onClose(object sender, FormClosingEventArgs e)
        {
            this.form?.setEnabled(true);
        }
    }
}
