const login = () => {
  const loginForm = $("form[name='loginForm']").serializeArray();

  let data = {};

  loginForm.forEach((field) => {
    if (field.name.includes("userName")) data["userName"] = field.value;
    else data["password"] = field.value;
  });

  localStorage.setItem("logged", data.userName);

  $.post("http://localhost:5000/api/user/login", data, (result) => {
    if (result) location.href = "index.html";
  });
};
