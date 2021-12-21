using System.ComponentModel.DataAnnotations;

namespace WebApiTest6.Models.V2;

public class WeatherForecast
{
    [Key]
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }

    public Source? Source { get; set; }
}

public class Source
{
    public string? Name1 { get; set; }
    public string? Name2 { get; set; }
    public string? Name3 { get; set; }
    //public string? Name4 { get; set; }
    //public string? Name5 { get; set; }
    //public string? Name6 { get; set; }
    //public string? Name7 { get; set; }
    //public string? Name8 { get; set; }
    //public string? Name9 { get; set; }
    //public string? Name10 { get; set; }
    //public string? Name11 { get; set; }
    //public string? Name12 { get; set; }
    //public string? Name13 { get; set; }
    //public string? Name14 { get; set; }
    //public string? Name15 { get; set; }
    //public string? Name16 { get; set; }
    //public string? Name17 { get; set; }
    //public string? Name18 { get; set; }
    //public string? Name19 { get; set; }
    //public string? Name20 { get; set; }
    //public string? Name21 { get; set; }
    //public string? Name22 { get; set; }
    //public string? Name23 { get; set; }
    //public string? Name24 { get; set; }
    //public string? Name25 { get; set; }
    //public string? Name26 { get; set; }
    //public string? Name27 { get; set; }
    //public string? Name28 { get; set; }
    //public string? Name29 { get; set; }
    //public string? Name30 { get; set; }
    //public string? Name31 { get; set; }
    //public string? Name32 { get; set; }
    //public string? Name33 { get; set; }
    //public string? Name34 { get; set; }
    //public string? Name35 { get; set; }
    //public string? Name36 { get; set; }
    //public string? Name37 { get; set; }
    //public string? Name38 { get; set; }
    //public string? Name39 { get; set; }
    //public string? Name40 { get; set; }
    //public string? Name41 { get; set; }
    //public string? Name42 { get; set; }
    //public string? Name43 { get; set; }
    //public string? Name44 { get; set; }
    //public string? Name45 { get; set; }
    //public string? Name46 { get; set; }
    //public string? Name47 { get; set; }
    //public string? Name48 { get; set; }
    //public string? Name49 { get; set; }
    //public string? Name50 { get; set; }
    //public string? Name51 { get; set; }
    //public string? Name52 { get; set; }
    //public string? Name53 { get; set; }
    //public string? Name54 { get; set; }
    //public string? Name55 { get; set; }
    //public string? Name56 { get; set; }
    //public string? Name57 { get; set; }
    //public string? Name58 { get; set; }
    //public string? Name59 { get; set; }
    //public string? Name60 { get; set; }
    //public string? Name61 { get; set; }
    //public string? Name62 { get; set; }
    //public string? Name63 { get; set; }
    //public string? Name64 { get; set; }
    //public string? Name65 { get; set; }
    //public string? Name66 { get; set; }
    //public string? Name67 { get; set; }
    //public string? Name68 { get; set; }
    //public string? Name69 { get; set; }
    //public bool Name70 { get; set; }
    //public bool Name71 { get; set; }
    //public bool Name72 { get; set; }
    //public bool Name73 { get; set; }
    //public bool Name74 { get; set; }
    //public bool Name75 { get; set; }
    //public bool Name76 { get; set; }
    //public bool Name77 { get; set; }
    //public bool Name78 { get; set; }
    //public bool Name79 { get; set; }
    //public string? Name80 { get; set; }
    //public string? Name81 { get; set; }
    //public string? Name82 { get; set; }
    //public string? Name83 { get; set; }
    //public string? Name84 { get; set; }
    //public string? Name85 { get; set; }
    //public string? Name86 { get; set; }
    //public string? Name87 { get; set; }
    //public string? Name88 { get; set; }
    //public string? Name89 { get; set; }
    //public string? Name90 { get; set; }
    //public string? Name91 { get; set; }
    //public string? Name92 { get; set; }
    //public string? Name93 { get; set; }
    //public string? Name94 { get; set; }
    //public string? Name95 { get; set; }
    //public string? Name96 { get; set; }
    //public string? Name97 { get; set; }
    //public string? Name98 { get; set; }
    //public string? Name99 { get; set; }
    //public int Name100 { get; set; }
    //public int Name101 { get; set; }
}
