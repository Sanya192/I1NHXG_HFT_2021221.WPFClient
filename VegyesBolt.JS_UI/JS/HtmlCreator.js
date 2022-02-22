class HtmlCreator {
  static rest = new RestHandler("https://localhost", 7207);

  static async DrawHTMLMegyek() {
    const megyek = await this.rest.fetchGetMegyek();
    return `
            <table class="table ">
                <thead class="thead-dark">
                    <tr>
                        ${MegyeHandler.header
                          .map(
                            (element) => `
                            <th scope="col">${element}</th>`
                          )
                          .join("")} 
                         <th scope="col"></th>
                         <th scope="col"></th>
                    </tr>
                </thead>
                <tbody>
                    ${megyek
                      .map(
                        (element) => `
                    <tr id="#megye-${element.id}">
                        ${Array.from(
                          element,
                          (x) => `<td>${x.getValue()}</td>`
                        ).join("")}
                        <td><button class="btn btn-outline-info" data-megye-id="${
                          element.id
                        }">${HtmlResources.editIcon}</button></td>
                        <td><button class="btn btn-outline-danger" onclick="HtmlCreator.DeleteMegye(${
                          element.id
                        })" ">${HtmlResources.deleteIcon}
                        </button></td>
                    </tr>`
                      )
                      .join("")}
                </tbody>
            </table>`;
  }

  static async DeleteMegye(id) {
    await this.rest.fetchDeleteMegye(id).then(() => loaded());
  }
}
