using System;
using System.Collections.Generic;

namespace MVCAjax.Proxy
{
    public class ResponseProxy<TEntity> : ICloneable where TEntity : class, new()
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public bool Exitoso { get; set; }
        public IEnumerable<TEntity> Listado { get; set; }
        public TEntity objeto { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}