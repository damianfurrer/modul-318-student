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

        private void UniqueStations()
        {
            //Wenn beide Stationen eindeutig sind wird die ListView mit den passenden Verbindungen befüllt.
            if (m_StartStationUnique && m_EndStationUnique) //Wenn beide Stationen eindeutig sind wird die ListView mit den passenden Verbindungen befüllt.
            {
                livConnections.Items.Clear();
                livConnections.Items.AddRange(getConnectionsasListViewItem(cobStart.Text, cobEnd.Text));
            }
        }

        public string[] getAllStations(string Text)
        {
            //Alle zu dem Eingabetext passenden Stationen werden als Text Array zurück gegeben
            string[] array = new string[50];
            Stations stations2 = new Stations();
            stations2 = m_transport.GetStations(Text);
            for (int i = 0; i < stations2.StationList.Count && i < 50; i++)
            {
                array[i] = stations2.StationList[i].Name;
            }

            if (array == null)
            {
                array[0] = "Keine Stationen vorhanden";
            }

            return array;
        }

        public ListViewItem[] getConnectionsasListViewItem(string from, string to)
        {
            Connections connections2 = new Connections();
            //Ein ListViewItem array, aller zu den from- & to-Stationen passenden Verbindungen wird zurückgegeben. Das  ListViewItem enthält Von-Stationsname, Abfahrtszeit, Bis-Stationsname, Ankunftszeit & die Dauer in Minuten.
            connections2 = m_transport.GetConnections(from, to);
            
            ListViewItem[] liv = new ListViewItem[connections2.ConnectionList.Count];
            for(int i=0;i< connections2.ConnectionList.Count; i++)
            {
                liv[i] = new ListViewItem(connections2.ConnectionList[i].From.Station.Name);
                liv[i].SubItems.Add(DateTime.Parse(connections2.ConnectionList[i].From.Departure).ToShortTimeString());//connections2.ConnectionList[i].From.Departure.Substring(11,5));
                liv[i].SubItems.Add(connections2.ConnectionList[i].To.Station.Name);
                liv[i].SubItems.Add(DateTime.Parse(connections2.ConnectionList[i].To.Arrival).ToShortTimeString());
                liv[i].SubItems.Add(TimeSpan.Parse(connections2.ConnectionList[i].Duration.Substring(3)).TotalMinutes.ToString() + " min"); 
            }

            if (liv == null)
            {
                liv[0] = new ListViewItem("Keine Verbindungen vorhanden");
            }

            return liv;

        }

        private void cobEnd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //bei der Auswahl eines Vorschlages, wird gesetzt, dass dieser Text eine eindeutige Station ist & nicht mehr beim anschliessenden Textevent beachtet werden muss.
            m_ignoreend = true;
            m_EndStationUnique = true;
            //Wenn beide Stationstexte eindeutig sind wird die entsprechende Funktion ausgeführt.
            if (m_StartStationUnique && m_EndStationUnique) { UniqueStations(); }
        }

        private void cobStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bei der Auswahl eines Vorschlages, wird gesetzt, dass dieser Text eine eindeutige Station ist & nicht mehr beim anschliessenden Textevent beachtet werden muss.
            m_ignorestart = true;
            m_StartStationUnique = true;
            //Wenn beide Stationstexte eindeutig sind wird die entsprechende Funktion ausgeführt.
            if (m_StartStationUnique && m_EndStationUnique) { UniqueStations(); }
        }

        private void cobStart_TextUpdate(object sender, EventArgs e)
        {
            //Aus performance Gründen wird der Text nur neu geprüft, wenn die Text länge länger wird.
            if (cobStart.Text.Length > m_cobStartLenght)
            {
                m_StartStationUnique = OnTextUpdateGetStationName(cobStart,m_ignorestart);
                m_ignorestart = false;
                //Wenn beide Stationstexte eindeutig sind wird die entsprechende Funktion ausgeführt.
                if (m_StartStationUnique && m_EndStationUnique) { UniqueStations(); }
            }
            m_cobStartLenght = cobStart.Text.Length;

        }

        private void cobEnd_TextUpdate(object sender, EventArgs e)
        {
            //Aus performance Gründen wird der Text nur neu geprüft, wenn die Text länge länger wird.
            if (cobEnd.Text.Length > m_cobEndLenght)
            {
                m_EndStationUnique = OnTextUpdateGetStationName(cobEnd,m_ignoreend);
                m_ignoreend = false;
                //Wenn beide Stationstexte eindeutig sind wird die entsprechende Funktion ausgeführt.
                if (m_StartStationUnique && m_EndStationUnique) { UniqueStations(); }
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

        private void btnAbfahrtstafel_Click(object sender, EventArgs e)
        {
            //Zeigt Abfahtstafel Fenster an & übernimmt standardmässig die Start-Station.
            FormAbfahrtstafel abfahrtstafel = new FormAbfahrtstafel();
            abfahrtstafel.setCobStation(cobStart.Text);
            abfahrtstafel.setMainForm(this);
            abfahrtstafel.ShowDialog();
        }

        public bool OnTextUpdateGetStationName(System.Windows.Forms.ComboBox cob, bool ignore)
        {
            bool unique = false;
                string[] array = getAllStations(cob.Text);
                if (array.Length != 1)
                {
                    if (ignore != true)      //Bei einer Vorschlagsauswahl soll die Prüfung nicht durchlaufen werden & kann gesperrt werden
                    {
                        unique = false;
                        cob.Items.Clear();
                        int i = 0;
                        while (i < 50 && array[i] != null)
                        {
                            cob.Items.Add(array[i]);
                            i++;
                        }
                        cob.DroppedDown = true;
                        cob.SelectionStart = cob.Text.Length;
                    }
                }
                else
                {
                    cob.DroppedDown = false;
                    unique = true;
                    
                }
            return unique;
        }

        public void StationAtGoogleMaps(string Station)
        {
            Stations stations = new Stations();
            stations = m_transport.GetStations(Station);
            string coordinate = stations.StationList.First().Coordinate.XCoordinate.ToString() + ", " + stations.StationList.First().Coordinate.YCoordinate.ToString();
            System.Diagnostics.Process.Start("https://www.google.ch/maps/@" + coordinate);
        }

        private void pibMapStart_Click(object sender, EventArgs e)
        {
            if (m_StartStationUnique)
            {
                StationAtGoogleMaps(cobStart.Text);
            }
        }

        private void pibMapEnd_Click(object sender, EventArgs e)
        {
            if (m_EndStationUnique)
            {
                StationAtGoogleMaps(cobEnd.Text);
            }
        }

        
    }
}
