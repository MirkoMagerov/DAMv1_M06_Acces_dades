﻿using cat.itb.M6UF2EA3.Model;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2EA3.Maps
{
    public class DepartamentoMap : ClassMap<Departamento>
    {
        public DepartamentoMap()
        {
            // Nombre tabla
            Table("departamentos");

            // Identificador unico
            Id(x => x.Id);

            //Mapeo
            Map(x => x.Dnombre).Column("dnombre");

            Map(x => x.Loc).Column("loc");
        }
    }
}
