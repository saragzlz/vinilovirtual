

using System;
using System.Collections.Generic;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;

namespace ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual
{
public abstract class GenericBasicCP
{
protected GenericSessionCP CPSession;
protected GenericUnitOfWorkRepository unitRepo;

protected GenericBasicCP (GenericSessionCP currentSession)
{
        this.CPSession = currentSession;
        this.unitRepo = this.CPSession.UnitRepo;
}
protected GenericBasicCP()
{
        this.CPSession = null;
        this.unitRepo = null;
}
}
}

