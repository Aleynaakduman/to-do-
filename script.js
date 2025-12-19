const form = document.getElementById("todoForm");
const taskList = document.getElementById("taskList");
const API_URL = "http://localhost:5284/api/todo"; 

// Sayfa açıldığında verileri getir
async function loadTasks() {
    try {
        const response = await fetch(API_URL);
        const tasks = await response.json();
        taskList.innerHTML = ""; 
        tasks.forEach(task => addTaskToDOM(task));
    } catch (err) {
        console.error("Yükleme hatası:", err);
    }
}

// Yeni görev ekle
form.addEventListener("submit", async function(e) {
    e.preventDefault();

    const task = {
        title: document.getElementById("title").value,
        description: document.getElementById("description").value,
        dueDate: document.getElementById("date").value,
        priority: document.getElementById("priority").value,
        categoryId: document.getElementById("category").value,
        reminderTime: document.getElementById("time").value,
        isNotificationActive: document.getElementById("notification").checked,
        statusId: "open"
    };

    try {
        const response = await fetch(API_URL, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(task)
        });

        if (response.ok) {
            const newTask = await response.json();
            addTaskToDOM(newTask);
            form.reset();
        } else {
            console.error("Backend hata verdi:", await response.text());
        }
    } catch (err) {
        console.error("İstek hatası:", err);
    }
});

function addTaskToDOM(task) {
    const li = document.createElement("li");
    const categoryClass = task.categoryId === "Okul" ? "school" : (task.categoryId === "İş" ? "work" : "personal");
    li.className = categoryClass;

    li.innerHTML = `
        <strong>${task.title}</strong> - <small>${task.priority}</small><br>
        <p>${task.description || ""}</p>
        <small>${task.dueDate} ${task.reminderTime || ""}</small>
        <button class="delete">Sil</button>
    `;

    li.querySelector(".delete").addEventListener("click", async function() {
        try {
            const res = await fetch(`${API_URL}/${task.id}`, { method: "DELETE" });
            if (res.ok) li.remove();
        } catch (err) {
            console.error("Silme hatası:", err);
        }
    });

    taskList.appendChild(li);
}

loadTasks();