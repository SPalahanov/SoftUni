using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RawData;

namespace _07.RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tyre[] tyre;

        public Car(string model, int speed, int power, int  weight, string type, double tyre1ressure, int tyre1age, double tyre2ressure, int tyre2age, double tyre3ressure, int tyre3age, double tyre4ressure, int tyre4age)
        {
            this.Model = model;
            this.Engine = new Engine(speed , power);
            this.Cargo = new Cargo(weight, type);
            this.Tyres = new Tyre[4];
            this.Tyres[0] = new Tyre(tyre1ressure, tyre1age);
            this.Tyres[1] = new Tyre(tyre2ressure, tyre2age);
            this.Tyres[2] = new Tyre(tyre3ressure, tyre3age);
            this.Tyres[3] = new Tyre(tyre4ressure, tyre4age);
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public Tyre[] Tyres
        {
            get { return tyre; }
            set { tyre = value; }
        }
    }
}
