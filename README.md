![GitHub language count](https://img.shields.io/github/languages/count/ClaudiaAF/MCInventory?colorB=f33c1a)
![GitHub repo size](https://img.shields.io/github/repo-size/ClaudiaAF/MCInventory?colorB=f33c1a)
![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/ClaudiaAF/MCInventory?colorB=f33c1a)
![GitHub watchers](https://img.shields.io/github/watchers/ClaudiaAF/MCInventory?colorB=f33c1a)



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/github_username/repo_name">
    <img src="https://user-images.githubusercontent.com/64257497/121602481-a4204880-ca47-11eb-9c11-bb5760274e74.png "width="195" alt="logo" >
  </a>

  <h3 align="center">MCInventory</h3>

  <p align="center">
    Minecraft Inventory Tracker
    <br />
    <a href="https://github.com/claudiaAF/Sprecan"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/github_username/repo_name">View Demo</a>
    ·
    <a href="https://github.com/github_username/repo_name/issues">Report Bug</a>
    ·
    <a href="https://github.com/github_username/repo_name/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
<summary><h2 style="display: inline-block">Table of Contents</h2></summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li><a href="#getting-started">Getting Started</a>
    <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
      <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#features-and-functionality">Features and Functionality</a>
    </li>
    <li><a href="#concept-process">Concept Process</a>
    <ul>
        <li><a href="#ideation">Ideation</a></li>
         <li><a href="#wireframes">Wireframes</a></li>
      <li><a href="#entity-relationship-diagram">ERD</a></li>
      </ul>
    </li>
    <li><a href="#development-process">Development Process</a>
    <ul>
      <li><a href="#implementation">Implementation</a>
        <ul>
        <li><a href="#resources-used">Resources Used</a></li>
        <li><a href="#highlights">Highlights</a></li>
        <li><a href="#challenges">Challenges</a></li>
        </ul>
      </li>
      <li><a href="#future-implementation">Future Implementation</a></li>
      </ul>
    </li>
    <li>
      <a href="#final-outcome">Final Outcome</a>
      <ul>
        <li><a href="#mockups">Mockups</a></li>
        <li><a href="#video-demonstration">Video Demonstration</a></li>
      </ul>
    </li>    
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

![header](https://user-images.githubusercontent.com/64257497/121604465-da12fc00-ca4a-11eb-83fa-058a817c456f.png)

MCInventory is a practical way for users to interact with their inventory when they are not able to access their Minecraft game. MCInventory was created using 
C# and an MVC architecture, where MYSQL is used as the backing database.

### Built With
![c-sharp-c-logo-02F17714BA-seeklogo 1](https://user-images.githubusercontent.com/64257497/141105842-5ad7fb00-49ef-40ab-95a0-cede4800b553.png)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
![mysql-5-logo-png-transparent 1](https://user-images.githubusercontent.com/64257497/141105894-e55ab72b-86d4-47e2-b13e-97e806e19719.png)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
![WampServer-logo 1](https://user-images.githubusercontent.com/64257497/141105938-af7c5035-8b32-4f50-811a-b2985b9d833d.png)

## Getting Started
### Prerequisites
* Latest version of Visual Studio Code installed (v1.6.2)
* The C# <a href="https://code.visualstudio.com/docs/languages/csharp">plugin</a> 

### Installation
* Clone the repo
1. Open `Visual Studio Code` and navigate to the > `command palette` using `F1`
2. In the `command palette` text field type `gitcl`, then select `Git: Clone`
3. In the `repository url` enter `https://github.com/ClaudiaAF/MCInventory.git` and press `Enter`
4. Select the `local directory` to clone the project

<!-- USAGE EXAMPLES -->
## Features and Functionality
### Features 
Features of this application include:

![Group 5](https://user-images.githubusercontent.com/64257497/141111695-3bccd8e7-10a9-49e2-9b70-c248c8b16643.png)
* A welcome page introudcing the user to the website

![iMac-24-All-Colors-Mockup](https://user-images.githubusercontent.com/64257497/121604867-9d93d000-ca4b-11eb-85a1-f584c3a625aa.png)
* Inventory items are dynamically displayed in cards for the user to interact with
* The images, names and counts are dynamically displayed from the database
* The amounts of each item can be increased or decreased
* The user can craft items by clicking any of the craftable item buttons

![iMac-24-All-ffMockup](https://user-images.githubusercontent.com/64257497/121605038-f6636880-ca4b-11eb-8172-646ff7a79d6b.png)
* A contact section if the user would like to get in contact with the website developer.

### Functions
* The `web server` serves `dynamic HTML` and media content for the recipes and blocks (inventory) list. The data is retrieved from the `database` and displayed in `cards` and list items for the user to interact with.
* The app receives its inventory items and recipes from the `MySQL database` that it is connected to. The database contains data structures made for recipe and block tables. The recipe makes use of the blocks currently in the inventory to craft the recipes.
* Amounts of items can be altered in the inventory through an `input field`. This option also allows the user to craft more items as there are always enough of each item.
* The user is able to `craft items` from existing recipes in the database. This then increases the amount of that certain item in the inventory. The recipes are only able to be crafted if there are enough of each “ingredient” for the recipe.

## Concept Process
### Ideation
![Group 5371](https://user-images.githubusercontent.com/64257497/141113012-a21ca5ac-ab8c-444e-9fbb-89c7d89078f1.png)

### Wireframes
![Group 80](https://user-images.githubusercontent.com/64257497/141113329-990624e5-9b75-466a-81e7-1dc85b3f36d1.png)

### Entity Relationship Diagram
![Group 82](https://user-images.githubusercontent.com/64257497/141113600-01de1bc9-07f3-4e2f-b964-2f0e33ec014c.png)

## Development Process
### Implementation
#### Resources Used
Styilised Official Minecraft™ 3D Icons. 

#### Highlights
* Implementing the MySQL database with C# was a highlight as I had worked with MySQL once before.
* Working with an MVC architecture.
* The efficiency of serving data dynamically.

#### Challenges
* Getting the HTML to display correctly when being parsed in the server.
* Correctly structuring the databases and naming conventions throughout the project.
* Changing my design late in the term was a risky decision and a self-inflicted challenge.

### Future Implementation
* Connecting to the users actual Minecraft account and being able to manage the actual database of items.
* Making the content more dynamic by adding directly from the front-end and not doing it manually in the backend.

## Final Outcome
## Mockups
![8](https://user-images.githubusercontent.com/64257497/141118974-c05f67e2-a547-4744-bb7f-ea061cb4f975.png)

## Video Demonstration
Click <a href="https://drive.google.com/file/d/1h7B69wJSDqZx7cf0VLsJrjNgYeJYqC24/view?usp=sharing">here</a> to view the demonstration video.

<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/github_username/repo_name/issues) for a list of proposed features (and known issues).


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact

* **Claudia Ferreira** - 180181@virtualwindow.co.za
* **Project Link** - https://github.com/ClaudiaAF/MCInventory.git



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements

* [C# for visual studio code documentation](https://code.visualstudio.com/docs/languages/csharp)
* Lecturer Christof Enslin

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/github_username/repo.svg?style=for-the-badge
[contributors-url]: https://github.com/github_username/repo/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/github_username/repo.svg?style=for-the-badge
[forks-url]: https://github.com/github_username/repo/network/members
[stars-shield]: https://img.shields.io/github/stars/github_username/repo.svg?style=for-the-badge
[stars-url]: https://github.com/github_username/repo/stargazers
[issues-shield]: https://img.shields.io/github/issues/github_username/repo.svg?style=for-the-badge
[issues-url]: https://github.com/github_username/repo/issues
[license-shield]: https://img.shields.io/github/license/github_username/repo.svg?style=for-the-badge
[license-url]: https://github.com/github_username/repo/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=d0ac4b
[linkedin-url]: https://linkedin.com/in/ClaudiaAF
