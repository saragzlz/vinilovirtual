

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

public int New_ (string p_nombre, String p_pass, string p_imagen, string p_attribute)
{
        AdminEN adminEN = null;
        int oid;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Nombre = p_nombre;

        adminEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        adminEN.Imagen = p_imagen;

        adminEN.Attribute = p_attribute;



        oid = _IAdminRepository.New_ (adminEN);
        return oid;
}

public void Modify (int p_Admin_OID, string p_nombre, String p_pass, string p_imagen, string p_attribute)
{
        AdminEN adminEN = null;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Id = p_Admin_OID;
        adminEN.Nombre = p_nombre;
        adminEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        adminEN.Imagen = p_imagen;
        adminEN.Attribute = p_attribute;
        //Call to AdminRepository

        _IAdminRepository.Modify (adminEN);
}

public void Destroy (int id
                     )
{
        _IAdminRepository.Destroy (id);
}
}
}
