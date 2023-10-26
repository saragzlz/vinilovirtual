

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

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
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

public override IComentarioRepository ComentarioRepository {
        get
        {
                this.comentariorepository = new ComentarioRepository ();
                this.comentariorepository.setSessionCP (session);
                return this.comentariorepository;
        }
}

public override IFavoritosRepository FavoritosRepository {
        get
        {
                this.favoritosrepository = new FavoritosRepository ();
                this.favoritosrepository.setSessionCP (session);
                return this.favoritosrepository;
        }
}
}
}

