const addFields = () => {
  let count = $("#form-fields").children().length;

  count++;

  $("#form-fields").append(
    $(`
    <div class="mb-3">
      <label for="question-${count}" class="form-label">Pergunta ${count}</label>
      <input type="text" class="form-control" id="question-${count}" name="question-${count}">
    </div>
    `)
  );
};

const submitForm = () => {
  const formData = $("form[name='newForm']").serializeArray();

  let data = {};
  let questions = [];
  formData.forEach((item) => {
    if (item.name.includes("question"))
      questions.push({ Question: item.value });
    else data[`${item.name}`] = item.value;
  });

  data["user"] = localStorage.getItem("logged");
  data["fields"] = questions;

  $.post("http://localhost:5000/api/form", data, (result) => {
    if (result === "") location.href = "index.html";
  });
};
