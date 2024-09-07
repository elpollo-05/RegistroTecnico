@page "/Tecnicos/Index"
@inject Tecnicoservice tecnicoService
@inject NavigationManager navigationManager
@rendermode InteractiveServer

<PageTitle>Registro de Técnicos</PageTitle>

<div class= "container mt-4" >
    < div class= "shadow-lg rounded" >

        < style >
            .titulo - fondo - rosado - borde - negro {
    background - color: #ffcccc; /* Color rosado */
                border: 2px solid black;
    border - radius: 5px;
color: black;
padding: 10px;
}

            .boton - rosado {
    background - color: #ffcccc; /* Color rosado */
                border: 1px solid black;
color: black;
}

                .boton - rosado:hover {
                    background-color: #ff9999; /* Rosado más oscuro */
                    color: white;
                }

            .form - select, .form - control {
border: 1px solid black;
    border - radius: 4px;
    background - color: #f0f0f0;
            }

            .table thead th {
                background-color: #ffcccc; /* Color rosado */
                border - bottom: 2px solid black;
color: black;
            }

            .table tbody td {
                border: 1px solid black;
color: black;
            }

            .btn - outline - primary, .btn - outline - warning, .btn - outline - danger {
border: 1px solid black;
}

                .btn - outline - primary:hover, .btn-outline-warning:hover, .btn-outline-danger:hover {
                    background-color: black;
color: white;
                }

            .card - footer {
    background - color: #ffcccc; /* Color rosado */
                border - top: 2px solid black;
color: black;
}

            .icon - button {
padding: 0; /* Eliminar el padding para que solo se vea la imagen */
    background - color: transparent; /* Quitar el fondo */
border: none; /* Quitar el borde */
    box - shadow: none; /* Quitar cualquier sombra */
cursor: pointer; /* Cambiar el cursor al pasar por encima */
}

                .icon - button img {
                    width: 20px; /* Ajustar el tamaño de la imagen */
height: 20px; /* Ajustar el tamaño de la imagen */
vertical - align: middle; /* Asegura que la imagen esté centrada verticalmente */
                }
        </ style >

        < div class= "card-header text-center titulo-fondo-rosado-borde-negro" >
            < h3 >< strong > Registro de Técnicos</strong></h3>
        </div>

        <div class= "card-body" >

            < div class= "row" >
                < div class= "col-3" >
                    < label class= "col-form-label" >< strong > Filtrar por </ strong ></ label >
                </ div >
                < div class= "col-4" >
                    < label class= "col-form-label" >< strong > Búsqueda </ strong ></ label >
                </ div >
            </ div >

            < div class= "row align-items-center" >
                < div class= "col-3" >
                    < InputSelect class= "form-select" @bind - Value = "Filtro" >
                        < option value = "" selected disabled>Elija una opción</option>
                        <option value="Id">ID del Técnico</option>
                        <option value="Nombre">Nombre</option>
                        <option value="SueldoHora">Sueldo/Hora</option>
                    </InputSelect>
                </div>
                <div class= "col-4" >
                    < div class= "input-group" >
                        < input class= "form-control" @bind = "ValorFiltro" placeholder = "Buscar" />
                        < button type = "button" class= "icon-button" @onclick = "Buscar" >
                            < img src = "images/search-icon.png" alt = "Buscar" />
                        </ button >
                    </ div >
                </ div >
                < div class= "col-3 offset-2" >
                    < !--offset - 2 para alinear correctamente el botón -->
                    <button type="button" class= "btn btn-primary boton-rosado" @onclick = "PantallaCrear" >
                        Crear
                    </ button >
                </ div >
            </ div >

            < table class= "table table-bordered text-center mt-4" >
                < thead >
                    < tr >
                        < th > ID del Técnico</th>
                        <th>Nombres</th>
                        <th>Sueldo/Hora</th>
                        <th>Detalles</th>
                        <th>Modificar</th>
                        <th>Eliminar</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var tecnico in ListaTecnicos)
{
                        < tr >
                            < td > @tecnico.tecniCold </ td >
                            < td > @tecnico.nombre </ td >
                            < td > @tecnico.sueldoHora </ td >
                            < td >
                                < button type = "button" class= "icon-button" @onclick = "()=> PantallaObservar(tecnico.tecniCold)" >
                                    < img src = "images/eye-icon.png" alt = "Detalles" />
                                </ button >
                            </ td >
                            < td >
                                < button type = "button" class= "icon-button" @onclick = "()=> PantallaEditar(tecnico.tecniCold)" >
                                    < img src = "images/edit-icon.png" alt = "Modificar" />
                                </ button >
                            </ td >
                            < td >
                                < button type = "button" class= "icon-button" @onclick = "()=> PantallaEliminar(tecnico.tecniCold)" >
                                    < img src = "images/delete-icon.png" alt = "Eliminar" />
                                </ button >
                            </ td >
                        </ tr >
                    }
                </ tbody >
            </ table >
        </ div >

        < div class= "card-footer text-center" >
            < p >< strong > Total de Técnicos: </ strong > @ListaTecnicos.Count </ p >
        </ div >
    </ div >
</ div >

@code {
    public List<Tecnicos> ListaTecnicos { get; set; } = new List<Tecnicos>();

public string Filtro { get; set; } = string.Empty;
public string ValorFiltro { get; set; } = string.Empty;

protected override async Task OnInitializedAsync()
{
    ListaTecnicos = await tecnicoService.Listar(e => e.tecniCold > 0);
}

public void PantallaCrear() => navigationManager.NavigateTo("/Tecnicos/Create");

public void PantallaObservar(int id)
{
    navigationManager.NavigateTo($"/Tecnicos/Details/{id}");
}

public void PantallaEditar(int id)
{
    navigationManager.NavigateTo($"/Tecnicos/Edit/{id}");
}

public void PantallaEliminar(int id)
{
    navigationManager.NavigateTo($"/Tecnicos/Delete/{id}");
}

private async Task Buscar()
{
    if (ValorFiltro.Trim() != "")
    {
        if (Filtro == "Id" && int.TryParse(ValorFiltro, out int tecniCold))
            ListaTecnicos = await tecnicoService.Listar(e => e.tecniCold == tecniCold);
        else if (Filtro == "Nombre")
            ListaTecnicos = await tecnicoService.Listar(e => e.nombre.ToLower().Contains(ValorFiltro.ToLower()));
        else if (Filtro == "SueldoHora")
        {
            if (double.TryParse(ValorFiltro, out double sueldoHora))
            {
                ListaTecnicos = await tecnicoService.Listar(e => e.sueldoHora == sueldoHora);
            }
        }
    }
    else
        ListaTecnicos = await tecnicoService.Listar(e => e.tecniCold > 0);
}

private async Task Restablecer()
{
    ListaTecnicos = await tecnicoService.Listar(e => e.tecniCold > 0);
    Filtro = string.Empty;
    ValorFiltro = string.Empty;
}
}
