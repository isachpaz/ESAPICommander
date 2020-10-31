using System;
using System.Collections.Generic;
using System.Linq;
using ESAPICommander.Interfaces;
using VMS.TPS.Common.Model.API;

namespace ESAPICommander.Adapters
{
    public class StructureSetAdapter:IStructureSet
    {
        private StructureSet _structureSet;
        
        public StructureSetAdapter(StructureSet structureSet)
        {
            _structureSet = structureSet ?? throw new ArgumentNullException(nameof(structureSet));
        }

        public string Id => _structureSet.Id;

        public IEnumerable<IStructure> Structures => _structureSet.Structures.Select(x => new StructureAdapter(x));
    }
}