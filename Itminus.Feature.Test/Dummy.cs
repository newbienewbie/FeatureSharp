using System;

namespace Itminus.Feature.Test{
    public interface IDummy{}

    public class Dummy : IDummy{
        public Guid Guid{get;set;}
        public Dummy(){
            this.Guid=Guid.NewGuid();
        }
    }
}