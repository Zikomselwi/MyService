$(document).ready(function () {
    $('#servicesId').DataTable({
        "autoWidth": false,
        "responsive": true,
        "language": {
            "emptyTable": "لايوجد خدمات متاحة"
        }
    });
});

Editservice = (id, name, description, date, active) => {
    // تحديث الحقول في النموذج
    document.getElementById("ServiceId").value = id;
    document.getElementById("Name").value = name;
    document.getElementById("Description").value = description;
    document.getElementById("CreatedAt").value = new Date(date).toISOString().split("T")[0];
    var Active = document.getElementById("IsActive");
    if (active == "True")
        Active.checked = true;
    else
        Active.checked = false;
    // التأكد من تنسيق التاريخ
    //let formattedDate = new Date(date).toISOString().split("T")[0];
    //document.getElementById("DateCreate").value = formattedDate;

    //// تحديث الحقول الأخرى
    //document.getElementById("Statue").value = statue;
    //var Active = document.getElementById("serviceActive")=true;
    //if (active == "True")
    //    Active.checked = true;
    //else
    //    Active.checked = false;
    //// التعامل مع السيرة الذاتية
    //if (resume && resume !== "null") {
    //    document.getElementById("Resume").src = PathResum + resume;
    //} else {
    //    document.getElementById("Resume").src = "";
    //}

    document.getElementById("serviceModalLabel").innerHTML = lbTitleEdit;
};


function Rest() {
    document.getElementById("ServiceId").value = "";
    document.getElementById("Name").value = "";
    document.getElementById("Description").value = "";
    document.getElementById("CreatedAt").value = "";
    document.getElementById("active").value = false;
    document.getElementById("serviceModalLabel").innerHTML = lbTitleAdd;

}




