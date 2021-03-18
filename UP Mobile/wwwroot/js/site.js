$(document).ready(function () {
    $('#myTable').DataTable({
        //"paginate": false,
        
        "language": {
            "emptyTable": " ",
            "search": "Procurar:",
            "infoEmpty": " ",
            "info": " ",
            "lengthMenu": "Mostrar _MENU_ resultados",
            "paginate": {
                "first": " ",
                "last": " ",
                "next": " ",
                "previous": " "
            },
        },
    });
});