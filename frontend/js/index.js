window.onload = () => {
  const userLogged = localStorage.getItem("logged");

  $.get("http://localhost:5000/api/form", (res) => {
    res.forEach((form) => {
      if (userLogged === form.user) {
        $("#user-list-form").append(
          $(
            `<button id=${form.id} type="button" class="list-group-item list-group-item-action" onclick="cons(event)">
              ${form.title}
            </button>`
          )
        );
      } else {
        $("#other-list-form").append(
          $(
            `<button id=${form.id} type="button" class="list-group-item list-group-item-action" onclick="cons(event)">
              ${form.title}
            </button>`
          )
        );
      }
    });
  });

  $("#title").text(`Olá, ${userLogged}`);
};

const cons = (e) => {
  location.href = `form.html?id=${e.originalTarget.id}`;
};
