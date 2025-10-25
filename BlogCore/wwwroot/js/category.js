var dataTable;
$(document).ready(function () {
    cargarDataTable();
});

function cargarDataTable() {
    dataTable = $("#tblCategories").DataTable({
        "ajax": {
            "url": "/Admin/Categories/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idCategory", "width": "5%" },
            { "data": "nameCategory", "width": "40%" },
            { "data": "order", "width": "10%" },
            { "data": null, "width": "40%" }
            
        ],
        "columnDefs": [
            {
                data: null,
                targets: [3],
               
                "render": function (data,type,row,meta) {
                    return `<div class="text-center">
                                <a href="/Admin/Categories/Edit/${row.IdCategory }" class="btn btn-success text-white" style="cursor:pointer; width:140px;">
                                <i class="far fa-edit"></i> Editar
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Categories/Delete/${row.IdCategory}") class="btn btn-danger text-white" style="cursor:pointer; width:140px;">
                                <i class="far fa-trash-alt"></i> Borrar
                                </a>
                          </div>
                         `;
                }, "width": "40%"
            }

        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        }, "width": "100%"

    });
}
