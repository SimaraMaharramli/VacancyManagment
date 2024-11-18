 document.addEventListener("change", function (event) {
     debugger
     if (event.target && (event.target.id === "statusSelect" || event.target.id === "categorySelect")) {
         let status = document.getElementById("statusSelect").value;
         console.log(status);
         let category = document.getElementById("categorySelect").value;

         let statusEncoded = encodeURIComponent(status);
         let categoryEncoded = encodeURIComponent(category);
         let urlfinal = `/Home/Index?categoryId=${categoryEncoded}&sortold=${statusEncoded}`;

         window.location.href = urlfinal;
     }
 });