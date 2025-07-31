async function login() {
    const username = document.getElementById("username").value.trim();
    const password = document.getElementById("password").value.trim();
    const errorDiv = document.getElementById("error");

    if (!username || !password) {
        errorDiv.textContent = "Lütfen tüm alanları doldurun.";
        errorDiv.style.display = "block";
        return;
    }

    const endpoint = "https://localhost:7251/api/auth/advisor/login";
    const payload = { email: username, password };


    try {
        const response = await fetch(endpoint, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(payload)
        });

        if (response.ok) {
            const data = await response.json();
            // localStorage.setItem("token", data.token); // JWT varsa
            window.location.href = "/Mts/advisor/dashboard.html"; // <- Danışman yönlendirme
        } else {
            const errorData = await response.json();
            errorDiv.textContent = errorData.message || "Giriş başarısız.";
            errorDiv.style.display = "block";
        }
    } catch (error) {
        console.error("Login error:", error);
        errorDiv.textContent = "Sunucuya bağlanılamadı.";
        errorDiv.style.display = "block";
    }
}
