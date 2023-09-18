using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiJwt.Dtos;

public class ProductoListDto
{
    public int Id { get; set; }
    public string Nombre {get; set;}
    public decimal Precio { get; set;}
    public DateTime FechaCreacion {get; set;}
    public int MarcaId { get; set;}
    public MarcaDto Marca { get; set;}
    public int CategoriaId { get; set;}
    public CategoriaDto Categoria { get; set;}  
}
