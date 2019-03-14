using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace YandexWTest
{
    public partial class Form1 : Form
    {
        struct city
        {
            public string name;
            public string lat;
            public string lon;
            public int id;
            public city(string name, string lat, string lon)
            {
                this.name = name;
                this.lat = lat;
                this.lon = lon;
                id = -1;
            }
        }

        const string citiesList = "koord_russia.csv";
        Yapi yapi;
        List<city> Cities;
        List<city> ShortCities;
        bool changedCB = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox1.Enabled = false;
                string text = textBox1.Text;
                int interval = 0;
                try
                {
                    interval = Convert.ToInt32(text);
                }
                catch
                {
                    string dig = "";
                    foreach (char c in text)
                        if (c >= '0' && c <= '9')
                            dig += c;
                    if (dig != "")
                    {
                        textBox1.Text = dig;
                        interval = Convert.ToInt32(dig);
                    }
                    else
                    {
                        checkBox1.CheckState = CheckState.Unchecked;
                        textBox1.Enabled = true;
                    }
                }

                if (!textBox1.Enabled)
                {
                    timer1.Interval = interval * 1000;
                    timer1.Enabled = true;
                }
            }
            else
            {
                textBox1.Enabled = true;
                timer1.Enabled = false;
            }
        }


        private void buttonApplyApiKey_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBoxApiKey.Text))
            {
                yapi = new Yapi(textBoxApiKey.Text);
                textBoxApiKey.Enabled = false;
                buttonGet.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cities = new List<city>();
            using (var csvParser = new Parser(citiesList))
            {
                csvParser.ReadHeader();
                while (!csvParser.HasMoreRecords())
                {
                    var record = csvParser.GetRecord();
                    var c = new city(record["Город"] + "\\" + record["Регион"], record["lat"].Replace(',','.'), record["lng"].Replace(',', '.'));
                    Cities.Add(c);
                    comboBoxCities.Items.Add(c.name);
                }
            }
        }

        private void comboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedCB = true;
        }

        private void comboBoxCities_TextChanged(object sender, EventArgs e)
        {
            if (!changedCB)
            {
                var text = comboBoxCities.Text;
                if (!String.IsNullOrWhiteSpace(text))
                {
                    ShortCities = FindCity(text);
                    comboBoxCities.Items.Clear();
                    foreach (var c in ShortCities)
                        comboBoxCities.Items.Add(c.name);
                    comboBoxCities.SelectionStart = comboBoxCities.Text.Length;
                }
                else
                {
                    foreach (var c in Cities)
                        comboBoxCities.Items.Add(c.name);
                }
            }
            else
                changedCB = false;
        }

        city FindCityFullName(string name)
        {
            foreach (var c in Cities)
                if (c.name == name)
                    return c;
            return new city("", "", "");
        }

        List<city> FindCity(string part)
        {
            List<city> list = new List<city>();
            foreach (var c in Cities)
                if (c.name.Contains(part) || c.name.ToLower().Contains(part) || c.name.ToUpper().Contains(part))
                    list.Add(c);
            return list;
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            GetWeather();
        }

        void GetWeather()
        {
            string selectedCity = comboBoxCities.Text;
            if (!String.IsNullOrWhiteSpace(selectedCity))
            {
                city c = FindCityFullName(selectedCity);
                if (!String.IsNullOrWhiteSpace(c.name))
                {
                    yapi.GetWeather(c.lat, c.lon, 1);
                    RefreshStats();
                }
            }
        }

        void RefreshStats()
        {
            var w = yapi.weather;
            labelCity.Text = comboBoxCities.Text;
            labelTemp.Text = w.fact.temp.ToString() + " C";
            labelFeelLike.Text = w.fact.feels_like.ToString() + " C";
            labelWindSpeed.Text = w.fact.wind_speed.ToString() + "m/s";
            labelWindDir.Text = w.fact.wind_dir.ToString();
            labelHumidity.Text = w.fact.humidity.ToString() + "%";
            labelPressure.Text = w.fact.pressure_mm.ToString() + "mm";
            labelLastUpdate.Text = w.now_dt.ToString();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            GetWeather();
        }
    }
}
