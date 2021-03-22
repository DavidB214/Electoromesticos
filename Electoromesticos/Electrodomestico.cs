using System;
using System.Collections.Generic;
using System.Text;

namespace Electrodomesticos
{
    #region Electrodomestico
    public class Electrodomestico
    {
        #region atributos
        //informacion valida
        public enum colores { blanco, negro, rojo, azul, gris };
        public enum consumoElectrico { A, B, C, D, E, F };
        //Datos por defecto
        const colores colorD = colores.blanco;
        const char consumoD = 'F';
        const decimal precioBaseD = 100;
        const int pesoD = 5;

        private decimal _precioBase;
        private colores _color;
        private consumoElectrico _consumo;
        private int _peso;
        #endregion
        #region Getters
        public decimal PrecioBase { get => _precioBase; set => _precioBase = value; }
        public colores Color { get => _color; set => _color = value; }
        public consumoElectrico Consumo { get => _consumo; set => _consumo = value; }
        public int Peso { get => _peso; set => _peso = value; }
        #endregion
        #region Constructors
        public Electrodomestico() : this(precioBaseD, pesoD)    
        { }        
        public Electrodomestico(decimal precio,int peso) : this(precio,consumoD , colorD.ToString(), peso)
        {}
        public Electrodomestico(decimal precio,char consumo,String color, int peso)
        {
            _precioBase = precio;
            _consumo = comprobarConsumoEnergetico(consumo);
            _color = comprobarColor(color);
            _peso = peso;

        }
        #endregion
        #region metodos
        public override string ToString()
        {
            return "precio="+_precioBase+" consumo="+_consumo+" color="+_color+" Peso en KG="+_peso;
        }

        public consumoElectrico comprobarConsumoEnergetico(char letra)
        {
            consumoElectrico consumo;
            if(Enum.TryParse(letra+"", out consumo))
            {
                consumo=Enum.Parse<consumoElectrico>(letra+"");
            }
            else
            {
                consumo = Enum.Parse<consumoElectrico>(consumoD+"");
            }
            return consumo;
        }
        public colores comprobarColor(String color)
        {
            colores c = colorD;

            if (Enum.TryParse(color, out c))
            {
                c = Enum.Parse<colores>(color);
            }

            return c;
        }

        virtual public decimal precioFinal()
        {
            decimal precioTotal = _precioBase;
            switch (_consumo)
            {
                case consumoElectrico.A:precioTotal += 100; break;
                case consumoElectrico.B:precioTotal += 80; break;
                case consumoElectrico.C:precioTotal += 60; break;
                case consumoElectrico.D:precioTotal += 50; break;
                case consumoElectrico.E:precioTotal += 30; break;
                case consumoElectrico.F:precioTotal += 10; break;
            }
            switch (_peso)//case int n when (n >= 0 && n <= 25):
                {
                case int n when(n<=19):precioTotal += 10; break;
                case int n when (n <= 49): precioTotal += 50; break;
                case int n when (n <= 79): precioTotal += 80; break;
                case int n when (n > 79): precioTotal += 100; break;
            }
            return precioTotal;
        }
        #endregion
    }
    #endregion

    #region Lavadora
    public class Lavadora : Electrodomestico
    {
        private int cargaD=5;
        private int _carga;

        public Lavadora():base()
        {
            Carga = cargaD;
        }

        public Lavadora(int precio, int peso) : base(precio, peso)
        {
            Carga = cargaD;
        }
        public Lavadora(int carga,decimal precio,String color,char consumo,int peso):base(precio, consumo,color, peso)
        {
            Carga = carga;
        }

        public int Carga { get => _carga; set => _carga = value; }

        public override decimal precioFinal()
        {
            if (Carga >= 30)
            {
                return PrecioBase + 50;
            }
            return base.precioFinal();
        }
    }
    #endregion

    #region Television
    public class Television : Electrodomestico
    {
        Boolean TDTD = false;
        int resolucionD = 20;
        int _resolucion;
        Boolean _TDT;
        public int Resolucion { get => _resolucion; set => _resolucion = value; }
        public bool TDT { get => _TDT; set => _TDT = value; }
        public Television():base()
        {
            _TDT = TDTD;
            _resolucion = resolucionD;
        }
        public Television(decimal precio,int peso):base(precio,peso)
        {
            _TDT = TDTD;
            _resolucion = resolucionD;
        }
        public Television(int res,Boolean tdt, decimal precio, char consumo, String color, int peso):base(precio,consumo,color,peso)
        {
            _TDT = tdt;
            _resolucion = res;
        }

        public override decimal precioFinal()
        {
            decimal precioFinal= base.precioFinal();
            if (_resolucion > 40)
                precioFinal = precioFinal* decimal.Parse("1.3");

            if (_TDT)
                precioFinal += 50;

            return precioFinal;
        }
    }
    #endregion
}
