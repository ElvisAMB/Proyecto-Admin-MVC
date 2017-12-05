$(function () {
  debugger;
  $("#grid").jqGrid({
    url: "/AgendaTelefonica/GetValues",
    datatype: 'json',
    mtype: 'Get',
    //table header name 
    colNames: ['Id', 'Nombres', 'Apellidos', 'Correo', 'Extensión', 'Estado'],
    //colModel takes the data from controller and binds to grid 
    colModel: [
        { key: true, hidden: true, name: 'Id', index: 'Id', editable: true },
        { key: false, name: 'FirstName', index: 'FirstName', editable: true },
        { key: false, name: 'LastName', index: 'LastName', editable: true },
        { key: false, name: 'Email', index: 'Email', editable: true },
        { key: false, name: 'Extension', index: 'Extension', editable: true },
        { key: false, name: 'Estado', index: 'Estado', editable: true }
        //{ key: false, name: 'DOB', index: 'DOB', editable: true, formatter: 'date', formatoptions: { newformat: 'd/m/Y' } }
    ],

    pager: jQuery('#pager'),
    rowNum: 10,
    rowList: [10, 20, 30, 40],
    height: '100%',
    viewrecords: true,
    caption: 'Teléfonos',
    emptyrecords: 'No records to display',
    jsonReader: {
      root: "rows",
      page: "page",
      total: "total",
      records: "records",
      repeatitems: false,
      Id: "0"
    },
    autowidth: true,
    multiselect: false
    //pager-you have to choose here what icons should appear at the bottom
    //like edit,create,delete icons
  }).navGrid('#pager', { edit: true, add: true, del: true, search: true, refresh: true },
      {
        // edit options
        zIndex: 100,
        url: '/AgendaTelefonica/Edit',
        closeOnEscape: true,
        closeAfterEdit: true,
        recreateForm: true,
        afterComplete: function (response) {
          if (response.responseText) {
            alert(response.responseText);
          }
        }
      },
      {
        // add options
        zIndex: 100,
        url: "/AgendaTelefonica/Create",
        closeOnEscape: true,
        closeAfterAdd: true,
        afterComplete: function (response) {
          if (response.responseText) {
            alert(response.responseText);
          }
        }
      },
      {
        // delete options
        zIndex: 100,
        url: "/AgendaTelefonica/Delete",
        closeOnEscape: true,
        closeAfterDelete: true,
        recreateForm: true,
        msg: "Are you sure you want to delete this task?",
        afterComplete: function (response) {
          if (response.responseText) {
            alert(response.responseText);
          }
        }
      },
      //jQuery("#grid").jqGrid('navGrid', '#pager', { edit: false, add: false, del: false }, {}, {}, {}, { multipleSearch: true, multipleGroup: true })
      );
});