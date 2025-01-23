using System;
using _2taldea;
using NHibernate;

public class ProduktuaAddClass
{
    private ISessionFactory sessionFactory;

    public ProduktuaAddClass(ISessionFactory sessionFactory)
    {
        this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
    }

    public bool AgregarProducto(string nombre, int stock, int max, int min, float prezioa, out string mensaje)
    {
        try
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                // Crear un nuevo producto
                var nuevoProducto = new Produktua
                {
                    Izena = nombre,
                    Stock = stock,
                    Max = max,
                    Min = min,
                    Prezioa = prezioa
                };

                // Guardar el producto en la base de datos
                session.Save(nuevoProducto);
                transaction.Commit();

                mensaje = "Producto añadido correctamente.";
                return true;
            }
        }
        catch (Exception ex)
        {
            mensaje = $"Error al añadir el producto: {ex.Message}";
            return false;
        }
    }
}
