import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import * as osu from 'node-osu';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    this.looper();
  }


  looper()
  {
    var osuApi = new osu.Api('43255b719ce00c4db94765e0ac0859e649af3f7d', {
      // baseUrl: sets the base api url (default: https://osu.ppy.sh/api)
      notFoundAsError: true, // Reject on not found instead of returning nothing. (default: true)
      completeScores: false // When fetching scores also return the beatmap (default: false)
    })


    osuApi.getBeatmaps({ b: 123 }).then(beatmaps =>
    {
      this.http.post<Maps[]>(this.baseUrl + "api/Map/InsertMap/", beatmaps[0]).subscribe();

      console.log(beatmaps);
    })

    /*
    for (var i = 1; i < 200; i++) {
      try {
        osuApi.getBeatmaps({ b: i }).then(beatmaps => {
         // console.log(beatmaps[0].title, beatmaps[0].artist, beatmaps[0].creator);
          this.inserttodb(beatmaps);
        });
      } catch (e) {
      */
  }

  inserttodb(maps)
  {
  }
}

interface Maps {
  Id: number;
  Name: string;
  Artist: string;
  Creator: string;
}
