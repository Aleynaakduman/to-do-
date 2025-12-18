const form = document.getElementById("todoForm");
const taskList = document.getElementById("taskList");

// LocalStorage'dan görevleri yükle
let tasks = JSON.parse(localStorage.getItem("tasks")) || [];
tasks.forEach(task => addTaskToDOM(task));

// Form submit işlemi
form.addEventListener("submit", function(e) {
    e.preventDefault();

    const task = {
        title: document.getElementById("title").value,
        description: document.getElementById("description").value,
        date: document.getElementById("date").value,
        priority: document.getElementById("priority").value,
        category: document.getElementById("category").value,
        time: document.getElementById("time").value,
        notification: document.getElementById("notification").checked,
        done: false
    };

    tasks.push(task);
    localStorage.setItem("tasks", JSON.stringify(tasks));

    addTaskToDOM(task);
    form.reset();
});

// Görevi DOM'a ekleme
function addTaskToDOM(task) {
    const li = document.createElement("li");

    li.innerHTML = `
        <input type="checkbox" class="check" ${task.done ? "checked" : ""}>
        <strong>${task.title}</strong><br>
        Açıklama: ${task.description}<br>
        Tarih: ${task.date}<br>
        Saat: ${task.time}<br>
        Öncelik: ${task.priority}<br>
        Kategori: ${task.category}
        <button class="delete">Sil</button>
    `;

    // Checkbox tamamlandı işlemi
    const checkbox = li.querySelector(".check");
    checkbox.addEventListener("change", function() {
        task.done = this.checked;
        if (task.done) li.classList.add("done");
        else li.classList.remove("done");
        localStorage.setItem("tasks", JSON.stringify(tasks));
    });

    // Silme butonu
    const deleteBtn = li.querySelector(".delete");
    deleteBtn.addEventListener("click", function() {
        taskList.removeChild(li);
        tasks = tasks.filter(t => t !== task);
        localStorage.setItem("tasks", JSON.stringify(tasks));
    });

    if(task.done) li.classList.add("done");

    taskList.appendChild(li);
}