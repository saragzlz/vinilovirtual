
using System;
using System.Collections.Generic;
using System.Text;

namespace ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual
{
public abstract class GenericUnitOfWorkRepository
{
protected IAdminRepository adminrepository;
protected IAlbumRepository albumrepository;
protected IArtistaRepository artistarepository;
protected IComunidadRepository comunidadrepository;
protected IComentarioRepository comentariorepository;
protected IPedidoRepository pedidorepository;
protected ILineaPedidoRepository lineapedidorepository;
protected IUsuarioRepository usuariorepository;


public abstract IAdminRepository AdminRepository {
        get;
}
public abstract IAlbumRepository AlbumRepository {
        get;
}
public abstract IArtistaRepository ArtistaRepository {
        get;
}
public abstract IComunidadRepository ComunidadRepository {
        get;
}
public abstract IComentarioRepository ComentarioRepository {
        get;
}
public abstract IPedidoRepository PedidoRepository {
        get;
}
public abstract ILineaPedidoRepository LineaPedidoRepository {
        get;
}
public abstract IUsuarioRepository UsuarioRepository {
        get;
}
}
}
