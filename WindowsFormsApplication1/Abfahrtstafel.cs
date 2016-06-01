using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwissTransport;

namespace WindowsFormsApplication1
{
    public partial class FormAbfahrtstafel : Form
    {
        Transport m_transport = new Transport();
        bool m_ignoreStation;
        bool m_StationUnique;
        int m_cobStationLenght;


        public FormAbfahrtstafel()
        {
            InitializeComponent();
        }

        private void cobStation_TextUpdate(object sender, EventArgs e)
        {
            //Aus performance Gründen wird der Text nur neu geprüft, wenn die Text länge länger wird.
            m_StationUnique = false;
            if (cobStation.Text.Length > m_cobStationLenght)
            {
                Cursor.Current = Cursors.WaitCursor;
                m_StationUnique = Functions.OnTextUpdateGetStationName(cobStation, m_ignoreStation);
                m_ignoreStation = false;
                //Wenn beide Stationstexte eindeutig sind wird die entsprechende Funktion ausgeführt.
                if (m_StationUnique) { UniqueStation(); }
                Cursor.Current = Cursors.Default;
            }
            m_cobStationLenght = cobStation.Text.Length;
        }

        private void cobStation_Enter(object sender, EventArgs e)
        {
            cobStation.DroppedDown = true;
        }

        private void cobStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bei der Auswahl eines Vorschlages, wird gesetzt, dass dieser Text eine eindeutige Station ist & nicht mehr beim anschliessenden Textevent beachtet werden muss.
            m_ignoreStation = true;
            m_StationUnique = true;
            UniqueStation();
        }

        private void pibMapStation_Click(object sender, EventArgs e)
        {
            if (m_StationUnique)
            {
                Functions.StationAtGoogleMaps(cobStation.Text);
            }
        }

        public void UniqueStation()
        {
            livAbfahrtstafel.Items.Clear();
            livAbfahrtstafel.Items.AddRange(getStationBoardasListViewItem(cobStation.Text));
        }

        public void setCobStation(string station)
        {
            m_StationUnique = true;
            cobStation.Text = station;
        }


        public ListViewItem[] getStationBoardasListViewItem(string Station)
        {
            Stations stations = new Stations();
            stations = m_transport.GetStations(Station);
            string id = stations.StationList.First().Id;
            StationBoardRoot boardroot;
            try
            {
                boardroot = m_transport.GetStationBoard(Station, id);
            }
            catch(Exception e)
            {
                ListViewItem[] liv2 = new ListViewItem[1];
                liv2[0] = new ListViewItem("FEHLER");
                liv2[0].SubItems.Add(e.Message);
                return liv2;

            }
            ListViewItem[] liv = new ListViewItem[boardroot.Entries.Count];
            int i = 0;
            foreach (StationBoard board in boardroot.Entries)
            {
                liv[i] = new ListViewItem(board.Name);
                liv[i].SubItems.Add(board.Operator);
                liv[i].SubItems.Add(board.Stop.Departure.ToShortTimeString());
                liv[i].SubItems.Add(board.To);
                i++;
            }

            if (liv == null)
            {
                liv[0] = new ListViewItem("Keine Abfahrtstafel vorhanden");
            }

            return liv;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
