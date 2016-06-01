using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissTransport;

namespace WindowsFormsApplication1
{
    class Functions
    {
        
        public static bool OnTextUpdateGetStationName(System.Windows.Forms.ComboBox cob, bool ignore)
        {
            bool unique = false;
            string[] array = getAllStations(cob.Text);
            if (array[1] != null)
            {
                if (ignore != true)      //Bei einer Vorschlagsauswahl soll die Prüfung nicht unnötig durchlaufen werden & kann gesperrt werden
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
                cob.DroppedDown = true;
                if (array[0] != null)
                {
                    cob.Items.Clear();
                    cob.Items.Add(array[0]);
                    cob.SelectionStart = cob.Text.Length;
                    unique = true;
                }
            }
            return unique;
        }

        public static void StationAtGoogleMaps(string Station)
        {
            Transport m_transport = new Transport();
            Stations stations = new Stations();
            stations = m_transport.GetStations(Station);
            string coordinate = stations.StationList.First().Coordinate.XCoordinate.ToString() + "," + stations.StationList.First().Coordinate.YCoordinate.ToString();
            System.Diagnostics.Process.Start("https://www.google.ch/maps?q=" + coordinate + "&t=k&z=21");
        }

        public static string[] getAllStations(string Text)
        {
            //Alle zu dem Eingabetext passenden Stationen werden als Text Array zurück gegeben
            Transport m_transport = new Transport();
            string[] array = new string[50];
            Stations stations2 = new Stations();
            try
            {
                stations2 = m_transport.GetStations(Text);
            }
            catch(Exception e)
            {
                array[0] = "FEHLER";
                array[1] = e.Message;
                return array;
            }
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


    }
}
