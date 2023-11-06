

using System;
using System.Text;
using System.Collections.Generic;

using ViniloVirtualGen.ApplicationCore.Exceptions;

using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using Newtonsoft.Json;


namespace ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioRepository _IUsuarioRepository;

public UsuarioCEN(IUsuarioRepository _IUsuarioRepository)
{
        this._IUsuarioRepository = _IUsuarioRepository;
}

public IUsuarioRepository get_IUsuarioRepository ()
{
        return this._IUsuarioRepository;
}

public int New_ (string p_nombre, string p_apillidos, String p_pass, string p_imagen, string p_attribute, string p_fechaNac, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum p_genero)
{
        UsuarioEN usuarioEN = null;
        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nombre = p_nombre;

        usuarioEN.Apillidos = p_apillidos;

        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        usuarioEN.Imagen = p_imagen;

        usuarioEN.Attribute = p_attribute;

        usuarioEN.FechaNac = p_fechaNac;

        usuarioEN.Genero = p_genero;



        oid = _IUsuarioRepository.New_ (usuarioEN);
        return oid;
}

public void Modify (int p_Usuario_OID, string p_nombre, string p_apillidos, String p_pass, string p_imagen, string p_attribute, string p_fechaNac, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.GeneroUsuarioEnum p_genero)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Id = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Apillidos = p_apillidos;
        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        usuarioEN.Imagen = p_imagen;
        usuarioEN.Attribute = p_attribute;
        usuarioEN.FechaNac = p_fechaNac;
        usuarioEN.Genero = p_genero;
        //Call to UsuarioRepository

        _IUsuarioRepository.Modify (usuarioEN);
}

public void Destroy (int id
                     )
{
        _IUsuarioRepository.Destroy (id);
}

public UsuarioEN GetID (int id
                        )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioRepository.GetID (id);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioRepository.GetAll (first, size);
        return list;
}
public string Login (int p_Usuario_OID, string p_pass)
{
        string result = null;
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (p_Usuario_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Id);

        return result;
}




private string Encode ()
{
        var payload = new Dictionary<string, object>(){
                {}
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (int id)
{
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (id);
        string token = Encode ();

        return token;
}
public int CheckToken (string token)
{
        int result = -1;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                int id = (int)ObtenerID (decodedToken);

                UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (id);

                if (en != null && ((long)en.Id).Equals (ObtenerID (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}
}
}
