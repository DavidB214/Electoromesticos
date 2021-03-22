using System;

namespace Electrodomesticos
{
    class Program
    {
        static void Main(string[] args)
        {
            Electrodomestico[] electrodomesticos = new Electrodomestico[10];
            electrodomesticos[0] = new Electrodomestico();
            electrodomesticos[1] = new Electrodomestico(200,40);
            electrodomesticos[2] = new Electrodomestico(150,'C',"Blanco",30);
            electrodomesticos[3] = new Lavadora();
            electrodomesticos[4] = new Lavadora(300,80);
            electrodomesticos[5] = new Lavadora(10,250, "NEGRO",'F',70);
            electrodomesticos[6] = new Television();
            electrodomesticos[7] = new Television(400,10);
            electrodomesticos[8] = new Television(45,true,500,'F',"RoJo",8);
            electrodomesticos[9] = new Electrodomestico();
            decimal precioTotalElectrodomesticos=0,
                precioTotalLavadoras=0,
                precioTotalTelevision=0;
            for (int i = 0; i < electrodomesticos.Length; i++)
            {
               // Console.WriteLine(electrodomesticos[i].precioFinal() + " "+electrodomesticos[i].GetType());
                decimal precio = electrodomesticos[i].precioFinal();
                if (electrodomesticos[i].GetType() == typeof(Lavadora))
                    precioTotalLavadoras += precio;
                else if (electrodomesticos[i].GetType() == typeof(Television))
                    precioTotalTelevision += precio;

                precioTotalElectrodomesticos += precio;
            }
            Console.WriteLine(precioTotalElectrodomesticos + " ELECTRODOMESTICOS");
            Console.WriteLine(precioTotalLavadoras + " LAVADORAS");
            Console.WriteLine(precioTotalTelevision + " TELEVISIONES");
        }
    }
}
