class HtmlCreator {
  static rest = RestHandler.getSingle();

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
                         <th scope="col"><button onclick="HtmlCreator.CreateMegye()" data-toggle="modal" data-target="#megye-modal"  class="btn btn-outline-success">${HtmlResources.addIcon}</button></th>
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
                        <td><button type="button" onclick="HtmlCreator.CreateMegyeEdit(${element.id})" class="btn btn-outline-info " data-toggle="modal" data-target="#megye-modal" data-megye-id="${
                          element.id
                        }">${HtmlResources.editIcon} </button></td>
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
      <div id="megye-modal-body" class="modal-body">
      
      </div>
     
    </div>
  </div>
</div>`
}
  static async DeleteMegye(id) {
    await this.rest.fetchDeleteMegye(id).then(() => loaded());
  }

    /**
     *
     * @param {MegyeHandler} megye
     * @returns {Promise<string>}
     * @constructor
     */
  static async EditMegye(megye){
    let megyeString= `
    <form id="megyeEdit-form" >
    <input type="hidden" name="id" value="${megye.id}"
    `+ this.MegyeFormFields(megye) + `<button type="button"  class="btn btn-primary" onclick="RestHandler.getSingle().formEditMegye()">Save changes</button>
    </form>`;
        document.getElementById("megye-modal-body").innerHTML=megyeString;
    }

    static async CreateMegye(){
      let megye= MegyeHandler.Empty();
        let megyeString= `
    <form id="megyeCreate-form">
    <input type="hidden" name="id" value="${megye.id}"
    `+ this.MegyeFormFields(megye) + `<button type="button"  class="btn btn-primary" onclick="RestHandler.getSingle().formCreateMegye()">Save changes</button>
    </form>`;
        document.getElementById("megye-modal-body").innerHTML=megyeString;
    }

    static MegyeFormFields(megye){
      return `<label>Nev</label>
    <input type="text" name="nev" value="${megye.nev}"><br>
    <label>Székhely</label>
    <input type="text" name="szekhely" value="${megye.szekhely}"><br>
    
    <label>Települések Száma</label>
    <input type="text" name="telepulesekSzama" value="${megye.telepulesekSzama}"><br>
    
    <label>Népesség</label>
    <input type="text" name="nepesseg" value="${megye.nepesseg}"><br>
     <label>Terület</label>
    <input type="text" name="terulet" value="${megye.terulet}"><br>
    
    `
    }
  static async CreateMegyeEdit(id){
      this.EditMegye(await this.rest.fetchGetMegye(id));
  }
}
