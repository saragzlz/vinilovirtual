

using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViniloVirtualGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IAdminRepository AdminRepository {
        get
        {
                this.adminrepository = new AdminRepository ();
                this.adminrepository.setSessionCP (session);
                return this.adminrepository;
        }
}

public override IAlbumRepository AlbumRepository {
        get
        {
                this.albumrepository = new AlbumRepository ();
                this.albumrepository.setSessionCP (session);
                return this.albumrepository;
        }
}

public override IArtistaRepository ArtistaRepository {
        get
        {
                this.artistarepository = new ArtistaRepository ();
                this.artistarepository.setSessionCP (session);
                return this.artistarepository;
        }
}

public override IComunidadRepository ComunidadRepository {
        get
        {
                this.comunidadrepository = new ComunidadRepository ();
                this.comunidadrepository.setSessionCP (session);
                return this.comunidadrepository;
        }
}

public override IPedidoRepository PedidoRepository {
        get
        {
                this.pedidorepository = new PedidoRepository ();
                this.pedidorepository.setSessionCP (session);
                return this.pedidorepository;
        }
}

public override ILineaPedidoRepository LineaPedidoRepository {
        get
        {
                this.lineapedidorepository = new LineaPedidoRepository ();
                this.lineapedidorepository.setSessionCP (session);
                return this.lineapedidorepository;
        }
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override IComentarioAlbRepository ComentarioAlbRepository {
        get
        {
                this.comentarioalbrepository = new ComentarioAlbRepository ();
                this.comentarioalbrepository.setSessionCP (session);
                return this.comentarioalbrepository;
        }
}

public override IComentarioComRepository ComentarioComRepository {
        get
        {
                this.comentariocomrepository = new ComentarioComRepository ();
                this.comentariocomrepository.setSessionCP (session);
                return this.comentariocomrepository;
        }
}
}
}

