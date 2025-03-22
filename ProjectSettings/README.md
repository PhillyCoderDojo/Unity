Follow these steps to deploy your Unity WebGL project using **GitHub Desktop** and **GitHub Pages**.

---

## 🎮 Step 1: Build Your Unity Project

1. Open Unity.

2. Go to **File → Build Settings**

3. Select **WebGL** as the platform.

4. Click **Build** (not Build and Run).

5. Choose a folder for your build output, e.g., `webgl-build/`.


---

## 📁 Step 2: Prepare the Files for GitHub


1. Open your build output folder (e.g., `webgl-build/`).

2. Create a folder called `docs/` in your Unity project root.

3. Copy **everything** from `webgl-build/` into the `docs/` folder.

   ```

   YourProject/

   ├── docs/

   │   ├── index.html

   │   ├── Build/

   │   └── TemplateData/

   └── README.md

   ```


> ✅ Make sure `index.html` is directly inside the `docs/` folder.

---
## 🧑‍💻 Step 3: Use GitHub Desktop to Upload

1. Open **GitHub Desktop**.

2. Click **File → New Repository** and choose your Unity project folder.

3. Name your repo and click **Create Repository**.

4. You should see the changes, including the `docs/` folder.

5. Write a commit message like `Add WebGL build`.

6. Click **Commit to main**.

7. Click **Publish repository** to push it to GitHub.

---

## 🌐 Step 4: Enable GitHub Pages

1. Go to your repository on [github.com](https://github.com).

2. Click **Settings → Pages** in the left sidebar.

3. Under **Source**, select:

   - Branch: `main`

   - Folder: `/docs`

1. Click **Save**.

GitHub will build your site and host it at:


```

https://your-username.github.io/your-repo/

