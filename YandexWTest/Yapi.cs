using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace YandexWTest
{
    class Yapi
    {
        string key = "";
        string api = "https://api.weather.yandex.ru/v1/forecast?";
        public Weather weather;
        public Yapi(string key)
        {
            this.key = key;
        }

        public void GetWeather(string lat, string lon, int limit)
        {
            WebRequest wr;
            wr = WebRequest.Create(api + "&lat=" + lat + "&lon=" + lon + "&limit=" + limit.ToString());
            wr.Headers.Set("X-Yandex-API-Key", key);
            using (StreamReader stream = new StreamReader(wr.GetResponse().GetResponseStream()))
            {
                var s = stream.ReadLine();
                if (s!=null)
                   weather = JsonConvert.DeserializeObject<Weather>(s);
            }
        }

        public class Tzinfo
        {
            public string name { get; set; }
            public string abbr { get; set; }
            public double offset { get; set; }
            public bool dst { get; set; }
        }

        public class Info
        {
            public bool f { get; set; }
            public bool n { get; set; }
            public bool nr { get; set; }
            public bool ns { get; set; }
            public bool nsr { get; set; }
            public bool p { get; set; }
            public double lat { get; set; }
            public double lon { get; set; }
            public double geoid { get; set; }
            public string slug { get; set; }
            public double zoom { get; set; }
            public Tzinfo tzinfo { get; set; }
            public double def_pressure_mm { get; set; }
            public double def_pressure_pa { get; set; }
            public bool _h { get; set; }
            public string url { get; set; }
        }

        public class AccumPrec
        {
            public double __invalid_name__1 { get; set; }
            public double __invalid_name__3 { get; set; }
            public double __invalid_name__7 { get; set; }
        }

        public class Fact
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public string icon { get; set; }
            public string condition { get; set; }
            public double wind_speed { get; set; }
            public double wind_gust { get; set; }
            public string wind_dir { get; set; }
            public double pressure_mm { get; set; }
            public double pressure_pa { get; set; }
            public double humidity { get; set; }
            public double uv_index { get; set; }
            public double soil_temp { get; set; }
            public double soil_moisture { get; set; }
            public string daytime { get; set; }
            public bool polar { get; set; }
            public string season { get; set; }
            public double obs_time { get; set; }
            public AccumPrec accum_prec { get; set; }
            public string source { get; set; }
        }

        public class Night
        {
            public string _source { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double temp_avg { get; set; }
            public double feels_like { get; set; }
            public string icon { get; set; }
            public string condition { get; set; }
            public string daytime { get; set; }
            public bool polar { get; set; }
            public double wind_speed { get; set; }
            public double wind_gust { get; set; }
            public string wind_dir { get; set; }
            public double pressure_mm { get; set; }
            public double pressure_pa { get; set; }
            public double humidity { get; set; }
            public double uv_index { get; set; }
            public double soil_temp { get; set; }
            public double soil_moisture { get; set; }
            public double prec_mm { get; set; }
            public double prec_period { get; set; }
            public double prec_prob { get; set; }
        }

        public class Morning
        {
            public string _source { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double temp_avg { get; set; }
            public double feels_like { get; set; }
            public string icon { get; set; }
            public string condition { get; set; }
            public string daytime { get; set; }
            public bool polar { get; set; }
            public double wind_speed { get; set; }
            public double wind_gust { get; set; }
            public string wind_dir { get; set; }
            public double pressure_mm { get; set; }
            public double pressure_pa { get; set; }
            public double humidity { get; set; }
            public double uv_index { get; set; }
            public double soil_temp { get; set; }
            public double soil_moisture { get; set; }
            public double prec_mm { get; set; }
            public double prec_period { get; set; }
            public double prec_prob { get; set; }
        }

        public class Day
        {
            public string _source { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double temp_avg { get; set; }
            public double feels_like { get; set; }
            public string icon { get; set; }
            public string condition { get; set; }
            public string daytime { get; set; }
            public bool polar { get; set; }
            public double wind_speed { get; set; }
            public double wind_gust { get; set; }
            public string wind_dir { get; set; }
            public double pressure_mm { get; set; }
            public double pressure_pa { get; set; }
            public double humidity { get; set; }
            public double uv_index { get; set; }
            public double soil_temp { get; set; }
            public double soil_moisture { get; set; }
            public double prec_mm { get; set; }
            public double prec_period { get; set; }
            public double prec_prob { get; set; }
        }

        public class Evening
        {
            public string _source { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double temp_avg { get; set; }
            public double feels_like { get; set; }
            public string icon { get; set; }
            public string condition { get; set; }
            public string daytime { get; set; }
            public bool polar { get; set; }
            public double wind_speed { get; set; }
            public double wind_gust { get; set; }
            public string wind_dir { get; set; }
            public double pressure_mm { get; set; }
            public double pressure_pa { get; set; }
            public double humidity { get; set; }
            public double uv_index { get; set; }
            public double soil_temp { get; set; }
            public double soil_moisture { get; set; }
            public double prec_mm { get; set; }
            public double prec_period { get; set; }
            public double prec_prob { get; set; }
        }

        public class DayShort
        {
            public string _source { get; set; }
            public double temp { get; set; }
            public double temp_min { get; set; }
            public double feels_like { get; set; }
            public string icon { get; set; }
            public string condition { get; set; }
            public double wind_speed { get; set; }
            public double wind_gust { get; set; }
            public string wind_dir { get; set; }
            public double pressure_mm { get; set; }
            public double pressure_pa { get; set; }
            public double humidity { get; set; }
            public double uv_index { get; set; }
            public double soil_temp { get; set; }
            public double soil_moisture { get; set; }
            public double prec_mm { get; set; }
            public double prec_prob { get; set; }
        }

        public class NightShort
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public string icon { get; set; }
            public string condition { get; set; }
            public double wind_speed { get; set; }
            public double wind_gust { get; set; }
            public string wind_dir { get; set; }
            public double pressure_mm { get; set; }
            public double pressure_pa { get; set; }
            public double humidity { get; set; }
            public double uv_index { get; set; }
            public double soil_temp { get; set; }
            public double soil_moisture { get; set; }
            public double prec_mm { get; set; }
            public double prec_prob { get; set; }
        }

        public class Parts
        {
            public Night night { get; set; }
            public Morning morning { get; set; }
            public Day day { get; set; }
            public Evening evening { get; set; }
            public DayShort day_short { get; set; }
            public NightShort night_short { get; set; }
        }

        public class Forecast
        {
            public string date { get; set; }
            public double date_ts { get; set; }
            public double week { get; set; }
            public string sunrise { get; set; }
            public string sunset { get; set; }
            public string rise_begin { get; set; }
            public string set_end { get; set; }
            public double moon_code { get; set; }
            public string moon_text { get; set; }
            public Parts parts { get; set; }
            public List<object> hours { get; set; }
        }

        public class Weather
        {
            public double now { get; set; }
            public DateTime now_dt { get; set; }
            public Info info { get; set; }
            public Fact fact { get; set; }
            public List<Forecast> forecasts { get; set; }
        }
    }

}
