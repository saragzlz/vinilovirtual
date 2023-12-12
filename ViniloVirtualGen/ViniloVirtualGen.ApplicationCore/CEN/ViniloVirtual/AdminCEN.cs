

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
/*
 *      Definition of the class AdminCEN
 *
 */
public partial class AdminCEN
{
private IAdminRepository _IAdminRepository;

public AdminCEN(IAdminRepository _IAdminRepository)
{
        this._IAdminRepository = _IAdminRepository;
}

public IAdminRepository get_IAdminRepository ()
{
        return this._IAdminRepository;
}

public string New_ (string p_nombre, String p_pass, string p_email, Nullable<DateTime> p_fechaNac, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum p_genero, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum p_estado, string p_imagen, string p_apellido, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum p_tipo)
{
        AdminEN adminEN = null;
        string oid;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Nombre = p_nombre;

        adminEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        adminEN.Email = p_email;

        adminEN.FechaNac = p_fechaNac;

        adminEN.Genero = p_genero;

        adminEN.Estado = p_estado;

        adminEN.Imagen = p_imagen;

        adminEN.Apellido = p_apellido;

        adminEN.Tipo = p_tipo;



        oid = _IAdminRepository.New_ (adminEN);
        return oid;
}

public void Modify (string p_Admin_OID, string p_nombre, String p_pass, Nullable<DateTime> p_fechaNac, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum p_genero, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum p_estado, string p_imagen, string p_apellido, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum p_tipo)
{
        AdminEN adminEN = null;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Email = p_Admin_OID;
        adminEN.Nombre = p_nombre;
        adminEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        adminEN.FechaNac = p_fechaNac;
        adminEN.Genero = p_genero;
        adminEN.Estado = p_estado;
        adminEN.Imagen = p_imagen;
        adminEN.Apellido = p_apellido;
        adminEN.Tipo = p_tipo;
        //Call to AdminRepository

        _IAdminRepository.Modify (adminEN);
}

public void Destroy (string email
                     )
{
        _IAdminRepository.Destroy (email);
}
}
}
