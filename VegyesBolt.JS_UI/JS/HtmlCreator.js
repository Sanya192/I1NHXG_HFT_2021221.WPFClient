class HtmlCreator {
  static rest = new RestHandler("https://localhost", 5001);

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
                        <td><button type="button" class="btn btn-outline-info " data-toggle="modal" data-target="#megye-modal" data-megye-id="${
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
static async CreateMegyeModal(){
      return `<div id="megye-modal" class="modal fade" tabindex="-1" role="dialog" >
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Megye Szerkesztése</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
      
        <p>Modal body text goes here.</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary">Save changes</button>
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>`
}
  static async DeleteMegye(id) {
    await this.rest.fetchDeleteMegye(id).then(() => loaded());
  }
}
