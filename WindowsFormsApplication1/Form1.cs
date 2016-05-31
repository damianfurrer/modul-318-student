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
    public partial class Form1 : Form
    {
        Transport m_transport = new Transport();
        bool m_StartStationUnique;
        bool m_EndStationUnique;
        bool m_ignoreend;
        bool m_ignorestart;
        int m_cobStartLenght;
        int m_cobEndLenght;
        //Stations stationsEnd = new Stations();

        public Form1()
        {
            InitializeComponent();
        }

    private void button1_Click(object sender, EventArgs e)
        {
            //=============TEST BUTTON=============\\
            livConnections.Items.Clear();
            livConnections.Items.AddRange(getConnectionsasListViewItem(cobStart.Text, cobEnd.Text));
            StationBoardRoot stationboardroot = new StationBoardRoot();
            StationBoardRoot rootboard = m_transport.GetStationBoard("Luzern","1");
            List<StationBoard> board = rootboard.Entries;
            foreach(StationBoard b in board)
            {
                livConnections.Items.Add(b.Name);
            }

        }


        private void cobStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bei der Auswahl eines Vorschlages, wird gesetzt, dass dieser Text eine eindeutige Station ist & nicht mehr beim anschliessenden Textevent beachtet werden muss.
            m_ignorestart = true;
            m_StartStationUnique = true;
            //Wenn beide Stationstexte eindeutig sind wird die entsprechende Funktion ausgeführt.
            if (m_StartStationUnique && m_EndStationUnique) { UniqueStations(); }
        }

        private void cobEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bei der Auswahl eines Vorschlages, wird gesetzt, dass dieser Text eine eindeutige Station ist & nicht mehr beim anschliessenden Textevent beachtet werden muss.
            m_ignoreend = true;
            m_EndStationUnique = true;
            //Wenn beide Stationstexte eindeutig sind wird die entsprechende Funktion ausgeführt.
            if (m_StartStationUnique && m_EndStationUnique) { UniqueStations(); }
        }

        private void cobStart_TextUpdate(object sender, EventArgs e)
        {
            m_StartStationUnique = false;
            //Aus performance Gründen wird der Text nur neu geprüft, wenn die Text länge länger wird.
            if (cobStart.Text.Length > m_cobStartLenght)
            {
                Cursor.Current = Cursors.WaitCursor;
                m_StartStationUnique = Functions.OnTextUpdateGetStationName(cobStart, m_ignorestart);
                m_ignorestart = false;
                //Wenn beide Stationstexte eindeutig sind wird die entsprechende Funktion ausgeführt.
                if (m_StartStationUnique && m_EndStationUnique) { UniqueStations(); }
                Cursor.Current = Cursors.Default;
            }
            m_cobStartLenght = cobStart.Text.Length;

        }

        private void cobEnd_TextUpdate(object sender, EventArgs e)
        {
            m_EndStationUnique = false;
            //Aus performance Gründen wird der Text nur neu geprüft, wenn die Text länge länger wird.
            if (cobEnd.Text.Length > m_cobEndLenght)
            {
                Cursor.Current = Cursors.WaitCursor;
                m_EndStationUnique = Functions.OnTextUpdateGetStationName(cobEnd, m_ignoreend);
                m_ignoreend = false;
                //Wenn beide Stationstexte eindeutig sind wird die entsprechende Funktion ausgeführt.
                if (m_StartStationUnique && m_EndStationUnique) { UniqueStations(); }
                Cursor.Current = Cursors.Default;
            }
            m_cobEndLenght = cobEnd.Text.Length;
        }

        private void cobStart_Enter(object sender, EventArgs e)
        {
            cobStart.DroppedDown = true;
        }

        private void cobEnd_Enter(object sender, EventArgs e)
        {
            cobEnd.DroppedDown = true;
        }

        private void btnAbfahrtstafelStart_Click(object sender, EventArgs e)
        {
            //Zeigt Abfahtstafel Fenster an & übernimmt standardmässig die Start-Station.
            Cursor.Current = Cursors.WaitCursor;
            FormAbfahrtstafel abfahrtstafel = new FormAbfahrtstafel();
            if (m_StartStationUnique)
            {
                abfahrtstafel.setCobStation(cobStart.Text);
                abfahrtstafel.UniqueStation();
            }
            Cursor.Current = Cursors.Default;
            abfahrtstafel.ShowDialog();
        }

        private void btnAbfahrtstafelEnd_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Zeigt Abfahtstafel Fenster an & übernimmt standardmässig die End-Station.
            FormAbfahrtstafel abfahrtstafel = new FormAbfahrtstafel();
            if (m_EndStationUnique)
            {
                abfahrtstafel.setCobStation(cobEnd.Text);
                abfahrtstafel.UniqueStation();
            }
            Cursor.Current = Cursors.Default;
            abfahrtstafel.ShowDialog();
            
        }


        private void pibMapStart_Click(object sender, EventArgs e)
        {
            if (m_StartStationUnique)
            {
                Functions.StationAtGoogleMaps(cobStart.Text);
            }
        }

        private void pibMapEnd_Click(object sender, EventArgs e)
        {
            if (m_EndStationUnique)
            {
                Functions.StationAtGoogleMaps(cobEnd.Text);
            }
        }

        private void UniqueStations()
        {
            //Wenn beide Stationen eindeutig sind wird die ListView mit den passenden Verbindungen befüllt.
            if (m_StartStationUnique && m_EndStationUnique) //Wenn beide Stationen eindeutig sind wird die ListView mit den passenden Verbindungen befüllt.
            {
                livConnections.Items.Clear();
                livConnections.Items.AddRange(getConnectionsasListViewItem(cobStart.Text, cobEnd.Text));
            }
        }

        
        public ListViewItem[] getConnectionsasListViewItem(string from, string to)
        {
            Connections ConnectionsForListView = new Connections();
            //Ein ListViewItem array, aller zu den from- & to-Stationen passenden Verbindungen wird zurückgegeben. Das  ListViewItem enthält Von-Stationsname, Abfahrtszeit, Bis-Stationsname, Ankunftszeit & die Dauer in Minuten.
            ConnectionsForListView = m_transport.GetConnections(from, to);

            ListViewItem[] liv = new ListViewItem[ConnectionsForListView.ConnectionList.Count];
            for (int i = 0; i < ConnectionsForListView.ConnectionList.Count; i++)
            {
                liv[i] = new ListViewItem(ConnectionsForListView.ConnectionList[i].From.Station.Name);
                liv[i].SubItems.Add(ConnectionsForListView.ConnectionList[i].To.Station.Name);
                liv[i].SubItems.Add(DateTime.Parse(ConnectionsForListView.ConnectionList[i].From.Departure).ToShortTimeString());//connections2.ConnectionList[i].From.Departure.Substring(11,5));
                liv[i].SubItems.Add(DateTime.Parse(ConnectionsForListView.ConnectionList[i].To.Arrival).ToShortTimeString());
                liv[i].SubItems.Add(TimeSpan.Parse(ConnectionsForListView.ConnectionList[i].Duration.Substring(3)).TotalMinutes.ToString() + " min");
            }

            if (liv == null)
            {
                liv[0] = new ListViewItem("Keine Verbindungen vorhanden");
            }

            return liv;

        }       

    }
}
