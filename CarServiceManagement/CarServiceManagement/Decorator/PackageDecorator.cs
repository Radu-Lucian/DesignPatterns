﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceManagement.Decorator
{
    public abstract class PackageDecorator : IPackage
    {
        public IPackage DecoratedPackage { get; set; }

        public PackageDecorator(IPackage pack)
        {
            DecoratedPackage = pack;
        }

        public EPackageType Type { get ; set ; }
        public int Price { get ; set ; }
        public string ServicesIncluded { get ; set ; }

        public abstract void Update();

        public override string ToString()
        {
            return DecoratedPackage.ToString();
        }
    }
}
