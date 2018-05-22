using Core.Interfaces;

namespace Core.Services
{
    public class PreferenciasService : IPreferenciasService
    {
        public void GuardarPreferencias()
        {
            throw new System.NotImplementedException();
        }
    }
}

/*
Json:

{
	    "barrios": [
			{
				"IdBarrio":2
			},
			{
				"idBarrio":1
			}
	
    ],
    	
	    "caracteristicas": [
			{
				"IdCaracteristicas":2
			},
			{
				"IdCaracteristicas":1
			}
	
    ],
       "gastronomia": [
			{
				"IdGastronomia":2
			},
			{
				"IdGastronomia":1
			}
	
    ]
}

 */