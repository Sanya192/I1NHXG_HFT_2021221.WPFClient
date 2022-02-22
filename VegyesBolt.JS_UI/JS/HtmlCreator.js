 class HtmlCreator{
    static rest=new RestHandler("https://localhost",7207);
    static async CreateHTMLMegyek(){
        const megyek=(await this.rest.fetchGetMegyek());
        return `
            <div class="container">
            ${megyek.map((element)=>`
                <div class="row">
                ${Array.from(element,x=>`
                    <div class="col-sm">${x.getValue()}</div>`)} 
                </div>`)}
            </div>
             `;
    }
    static {
        console.log(`${this.name} is a static class`);
    }
}