ArchitectureScript
==================

A simple high-level DSL for defining software architecture using the C4 model described http://www.codingthearchitecture.com/2014/06/24/software_architecture_as_code.html. Generates json compatible with http://dev.structurizr.com/tryit

Pass in the files you want to convert into Structurizr views

A sample file might look like this:

    external person Anonymous User
      desc Anybody on the web
      uses kickthetable.com
        finds new and soon to be closing kickstarter campaigns
      uses Web Server
        finds new and soon to be closing kickstarter campaigns
      
    external person Administrator
      desc An authenticated user
      uses kickthetable.com
        maintains the list of kickstarter campaigns
      uses Web Server
        maintains the list of kickstarter campaigns
        
    external system Kickstarter
      desc kickstarter.com
      
    system kickthetable.com
      desc The premier way to find kickstarter campaigns in the Tabletop Games category
      container Web Server
        desc a web server
        tech ASP.NET MVC 4.5 on Azure Web Sites
      container Cache
        desc a cache of all of the campaigns on kickstarter in the Tabletop Games category
        tech Azure Caching
      
    view context kickthetable.com
    
    view containers kickthetable.com
