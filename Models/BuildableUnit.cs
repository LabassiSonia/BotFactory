using BotFactory.Common.Interface;

namespace BotFactory.Models
{
    public abstract class BuildableUnit : IBuildableUnit
    {
        //Fields
        private double _BuildTime;
        private string _Model;

        


        //Properties Implemntation
        public double BuildTime
        {
            get {return _BuildTime;}
            set {_BuildTime = value;}
        }
        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }

        //Constructors & methods
        public BuildableUnit(string model,double buildTime = 5)
        {
            this.BuildTime = buildTime;
            this.Model = model;
        }
        
    }
}
