window.onload = () => {
  var urlParams = new URLSearchParams(window.location.search);
  $.get(`http://localhost:5000/api/form/${urlParams.get("id")}`, (res) => {
    const date = new Date(res.createDate);

    $("#title").text(res.title);
    $("#date").text(date.toLocaleDateString("pt-BR"));

    const userLogged = localStorage.getItem("logged");

    if (res.user !== userLogged) {
      res.fields.forEach((fields, i) => {
        $("#fields").append(
          $(`
            <div class="mb-3">
              <label for="${fields.id}" class="form-label">${fields.question}</label>
              <textarea rows="3" type="text" class="form-control" id="${fields.id}" name="${fields.id}"></textarea>
            </div>
          `)
        );
      });
    } else {
      $("#btnSubmit").attr("hidden", true);
      $("#btnSubmit").prop("onclick", null).off("click");

      $.get(
        `http://localhost:5000/api/answer/form/${urlParams.get("id")}`,
        (res) => {
          res.forEach((item) => {
            $("#fields").append(
              $(`
                <div class="mb-3">
                  <div class="card">
                    <div class="card-body">
                      <h5 class="card-title">${item.formField.question}</h5>
                      <h6 class="card-subtitle mb-2 text-muted">
                        <a target="_blank" href="https://www.google.com/maps/@${item.latitude},${item.longitude},15z">
                          ${item.user.userName} - Localização
                        </a>
                      </h6>
                      <p class="card-text">${item.userAnswer}</p>
                    </div>
                  </div>
                </div>
              `)
            );
          });
        }
      );
    }
  });
};

const answerForm = () => {
  const userLogged = localStorage.getItem("logged");
  const formData = $("form[name='questions']").serializeArray();

  let answer = [];

  formData.forEach((item) => {
    const { name, value } = item;
    const temp = {
      idQuestion: Number(name),
      answer: value,
    };

    answer.push(temp);
  });

  navigator.geolocation.getCurrentPosition((e) => {
    const data = {
      user: userLogged,
      answers: answer,
      latitude: e.coords.latitude,
      longitude: e.coords.longitude,
    };

    $.post("http://localhost:5000/api/answer", data, (result) => {
      if (result === "") location.href = "index.html";
      alert("Formulário respondido!");
    });
  });
};
