import { Component, OnInit } from '@angular/core';
import { Meme } from '../meme';
import { MemesaverService } from '../memesaver.service';

@Component({
  selector: 'app-listimages',
  templateUrl: './listimages.component.html',
  styleUrls: ['./listimages.component.css']
})
export class ListimagesComponent implements OnInit {
  memeList: Meme[];

  constructor(private memeService: MemesaverService) { }

  ngOnInit(): void {
    this.GetAllImages();
  }

  GetAllImages() {
    this.memeService.GetAllImages().subscribe((reply) => {
      console.log(reply);
      this.memeList = reply;
    });

  }

}
