import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http'


@Component({
  selector: 'consumirApi-app',
  templateUrl:'./Pokemones.component.html'

})

export class ConsumirApi 
{
  name: any;
  p:number = 1;
  Pokemones: Result[] =[];

  Search(){
    this.Pokemones = this.Pokemones.filter(res=>{
      return res.name.toLocaleLowerCase().match(this.name.toLocaleLowerCase());
    })
    
  }

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    http.get<Result[]>(baseUrl + "api/PokeApi/Index").subscribe(result => {

      this.Pokemones = result;

    }, error => console.error(error));
  }
} 



interface Result
{
  name: string,
  url: string
}




